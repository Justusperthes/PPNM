Out.txt: main.exe
	mono main.exe > Out.txt

sfuns.dll : sfuns.cs
	mcs -target:library -out:sfuns.dll sfuns.cs

main.exe : main.cs sfuns.dll
	mcs -target:exe -out:main.exe -reference:sfuns.dll main.cs

.PHONEY:clean                         # clean is a phoney target, not a file
clean:                                # does not depend on anything
	rm --force Out.txt test.exe  # remove the files produced in the process of making

