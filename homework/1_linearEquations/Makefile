CODE = $(filter %.cs,$^)
LIBS = $(addprefix -reference:,$(filter %.dll,$^))
MKEXE = mcs -target:exe -out:$@ $(LIBS) $(CODE)
MKLIB = mcs -target:library -out:$@ $(LIBS) $(CODE)
CSC = mcs
RUN = mono

all: out.txt; cat $<

out.txt: main.exe
	$(RUN) $< > $@

out2: test.exe
	$(RUN) $< > $@

main.exe: main.cs matrix.dll QRGS.dll
	$(CSC) -reference:matrix.dll -reference:QRGS.dll $<

matrix.dll : vector.cs matrix.cs
	$(CSC) -target:library -out:$@ $^

QRGS.dll : QRGS.cs matrix.dll #; $(MKLIB)
	$(CSC) -reference:matrix.dll -target:library -out:$@ QRGS.cs

test.exe : test.cs
	$(CSC) $<

clean:
	$(RM) *.dll *.exe [Oo]ut*
