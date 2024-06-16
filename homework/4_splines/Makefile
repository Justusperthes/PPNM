CODE = $(filter %.cs,$^)
LIBS = $(addprefix -reference:,$(filter %.dll,$^))
MKEXE = mcs -target:exe -out:$@ $(LIBS) $(CODE)
MKLIB = mcs -target:library -out:$@ $(LIBS) $(CODE)
CSC = mcs
RUN = mono

all: out.txt; cat $<

out.txt: main.exe
	$(RUN) $< > $@

main.exe: main.cs lsplines.dll qsplines.dll GnuPlotHelper.dll
	$(CSC) -reference:lsplines.dll -reference:qsplines.dll -reference:GnuPlotHelper.dll $<

lsplines.dll : lsplines.cs #; $(MKLIB)
	$(CSC) -target:library -out:$@ lsplines.cs

qsplines.dll : qsplines.cs #; $(MKLIB)
	$(CSC) -target:library -out:$@ qsplines.cs

GnuPlotHelper.dll : main.cs GnuPlotHelper.cs
	$(CSC) -target:library -out:$@ GnuPlotHelper.cs

clean:
	$(RM) *.dll *.exe [Oo]ut*
