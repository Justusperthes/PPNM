CODE = $(filter %.cs,$^)
LIBS = $(addprefix -reference:,$(filter %.dll,$^))
MKEXE = mcs -target:exe -out:$@ $(LIBS) $(CODE)
MKLIB = mcs -target:library -out:$@ $(LIBS) $(CODE)
CSC = mcs
RUN = mono

all: out.txt

out.txt: main.exe
	$(RUN) $< > $@

main.exe: main.cs vector.dll RungeKutta.dll
	$(CSC) -reference:vector.dll -reference:RungeKutta.dll $<

vector.dll: vec.cs
	$(CSC) -target:library -out:$@ vec.cs

RungeKutta.dll: vec.cs RungeKutta.cs
	$(CSC) -reference:vector.dll -target:library -out:$@ RungeKutta.cs

clean:
	$(RM) *.dll *.exe *.txt