MESS := "fix"

git	:
	git add .
	git commit -m "${MESS}"
	git push
