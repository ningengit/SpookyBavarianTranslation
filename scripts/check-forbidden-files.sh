#!/bin/sh
set -eu

MODE="${1:---staged}"
ROOT="$(git rev-parse --show-toplevel)"

if [ "$MODE" = "--tracked" ]; then
    FILES="$(git -C "$ROOT" -c core.quotepath=false ls-files)"
elif [ "$MODE" = "--staged" ]; then
    FILES="$(git -C "$ROOT" -c core.quotepath=false diff --cached --name-only --diff-filter=ACMR)"
else
    echo "Usage: $0 [--staged|--tracked]" >&2
    exit 2
fi

if [ -z "$FILES" ]; then
    exit 0
fi

HITS="$(printf '%s\n' "$FILES" | grep -iE '(\.dll$|\.tpk$|(^|/)obj/|(^|/)bin/|(^|/)PublicizedAssemblies/)' || true)"
if [ -n "$HITS" ]; then
    echo "ERROR: Forbidden file(s) detected ($MODE):" >&2
    printf '%s\n' "$HITS" | sed 's/^/  - /' >&2
    echo "Remove generated build artifacts, .dll binaries, and .tpk files before committing." >&2
    exit 1
fi

exit 0
