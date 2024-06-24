CODE = $(filter %.cs,$^)
LIBS = $(addprefix -reference:,$(filter %.dll,$^))
MKEXE = mcs -target:exe -out:$@ $(LIBS) $(CODE)
MKLIB = mcs -target:library -out:$@ $(LIBS) $(CODE)
CSC = mcs
RUN = mono

all: out.txt; cat $<

out.txt: main.exe
	$(RUN) $< > $@

main.exe: main.cs vector.dll RK_integrator.dll
	$(CSC) -reference:RK_integrator.dll -reference:vector.dll $<

RK_integrator.dll : vector.cs RK_integrator.cs #; $(MKLIB)
	$(CSC) -reference:vector.dll -target:library -out:$@ RK_integrator.cs

vector.dll : vector.cs #; $(MKLIB)
	$(CSC) -target:library -out:$@ vector.cs

clean:
	$(RM) *.dll *.exe 
