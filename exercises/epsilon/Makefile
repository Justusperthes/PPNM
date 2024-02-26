Out.txt: epsilon.exe epsilon2.exe epsilon3.exe epsilon4.exe
	mono epsilon.exe > Out.txt
	mono epsilon2.exe >> Out.txt
	mono epsilon3.exe >> Out.txt
	mono epsilon4.exe >> Out.txt

epsilon.exe : epsilon.cs
	mcs epsilon.cs

epsilon2.exe : epsilon2.cs
	mcs epsilon2.cs

epsilon3.exe : epsilon3.cs
	mcs epsilon3.cs

epsilon4.exe : epsilon4.cs
	mcs epsilon4.cs

.PHONEY:clean                         # clean is a phoney target, not a file
clean:                                # does not depend on anything
	rm --force Out.txt epsilon.exe epsilon2.exe epsilon3.exe epsilon4.exe # remove the files produced in the process of making

