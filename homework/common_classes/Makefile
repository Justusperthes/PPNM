CODE = $(filter %.cs,$^)
LIBS = $(addprefix -reference:,$(filter %.dll,$^))
MKEXE = mcs -target:exe -out:$@ $(LIBS) $(CODE)
MKLIB = mcs -target:library -out:$@ $(LIBS) $(CODE)
CSC = mcs
RUN = mono

all: out.txt; cat $<

out.txt: main.exe
	$(RUN) $< > $@

main.exe: main.cs TestNamespace.cs
	$(CSC) $<

TestNamespace.dll : TestNamespace.cs
	$(CSC) -target:library -out:$@ $^

clean:
	$(RM) *.dll *.exe [Oo]ut*
