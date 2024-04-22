CODE = $(filter %.cs,$^)
LIBS = $(addprefix -reference:,$(filter %.dll,$^))
MKEXE = mcs -target:exe -out:$@ $(LIBS) $(CODE)
MKLIB = mcs -target:library -out:$@ $(LIBS) $(CODE)
CSC = mcs
RUN = mono

all: out.txt; cat $<

erf.gnuplot.png : out.txt erf.data.txt Makefile
	echo '\
	set terminal pngcairo enhanced font "arial,10" size 800,600 ;\
	set output "$@" ;\
	set xlabel "x" ;\
	set ylabel "erf(x)" ;\
	set title "Error function" ;\
	plot \
	"erf.data.txt" with lines title "Error function" \
	' | tee log.gpi | gnuplot

out.txt: main.exe
	$(RUN) $< > $@

erf.data.txt: main.exe
	$(RUN) $<

out2: test.exe
	$(RUN) $< > $@

main.exe: main.cs integ.dll 
	$(CSC) -reference:integ.dll $<

integ.dll : integ.cs #; $(MKLIB)
	$(CSC) -target:library -out:$@ integ.cs

test.exe : test.cs
	$(CSC) $<

clean:
	$(RM) *.dll *.exe [Oo]ut*
