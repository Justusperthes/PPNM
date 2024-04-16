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

main.exe: main.cs vector.dll mc.dll
	$(CSC) -reference:vector.dll -reference:mc.dll $<

vector.dll : vector.cs 
	$(CSC) -target:library -out:$@ vector.cs
	
mc.dll : mc.cs vector.dll
	$(CSC) -reference:vector.dll -target:library -out:$@ mc.cs

test.exe : test.cs
	$(CSC) $<

clean:
	$(RM) *.dll *.exe [Oo]ut*
