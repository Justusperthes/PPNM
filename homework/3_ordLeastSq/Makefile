CODE = $(filter %.cs,$^)
LIBS = $(addprefix -reference:,$(filter %.dll,$^))
MKEXE = mcs -target:exe -out:$@ $(LIBS) $(CODE)
MKLIB = mcs -target:library -out:$@ $(LIBS) $(CODE)
CSC = mcs
RUN = mono

all: out.txt; cat $<

decay.gnuplot.png : data.txt Makefile
	echo '\
	set terminal pngcairo enhanced font "arial,10" size 800,600 ;\
	set output "$@" ;\
	set xlabel "t (days)" ;\
	set ylabel "activity" ;\
	set title "Decay" ;\
	plot \
	"data.txt" with lines title "Exponential fit", \
	' | tee log.gpi | gnuplot

#decay.data.txt: main.exe
#	$(RUN) $<

out.txt: main.exe
	$(RUN) $< > $@

main.exe: main.cs matrix.dll ordLeastSq.dll QRGS.dll
	$(CSC) -reference:matrix.dll -reference:ordLeastSq.dll -reference:QRGS.dll $<

matrix.dll : vector.cs matrix.cs
	$(CSC) -target:library -out:$@ $^

QRGS.dll : QRGS.cs matrix.dll #; $(MKLIB)
	$(CSC) -reference:matrix.dll -target:library -out:$@ QRGS.cs

ordLeastSq.dll : ordLeastSq.cs matrix.dll QRGS.dll #; $(MKLIB)
	$(CSC) -reference:matrix.dll -reference:QRGS.dll -target:library -out:$@ ordLeastSq.cs

clean:
	$(RM) *.dll *.exe [Oo]ut*
