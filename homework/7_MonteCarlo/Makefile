CODE = $(filter %.cs,$^)
LIBS = $(addprefix -reference:,$(filter %.dll,$^))
MKEXE = mcs -target:exe -out:$@ $(LIBS) $(CODE)
MKLIB = mcs -target:library -out:$@ $(LIBS) $(CODE)
COMMON_CLASSES_DIR := ../common_classes
CSC = mcs
export MONO_PATH := $(COMMON_CLASSES_DIR)
RUN = mono --debug

all: error.gnuplot.png linerror.gnuplot.png comparison.gnuplot.png out.txt
	cat out.txt

error.gnuplot.png : out.txt error.data.txt Makefile
	@echo '\
	set terminal pngcairo enhanced font "arial,10" size 800,600 ;\
	set output "$@" ;\
	set xlabel "samples N" ;\
	set ylabel "error" ;\
	set title "Error as function of samples" ;\
	plot \
	"error.data.txt" with lines title "Error" \
	' | tee log.gpi | gnuplot

linerror.gnuplot.png : out.txt linerror.data.txt Makefile
	@echo '\
	set terminal pngcairo enhanced font "arial,10" size 800,600 ;\
	set output "$@" ;\
	set xlabel "N" ;\
	set ylabel "1/error^2" ;\
	set title "1/error^2 = k*N" ;\
	plot \
	"linerror.data.txt" with lines title "Modified error" \
	' | tee log.gpi | gnuplot

comparison.gnuplot.png : out.txt Makefile
	@echo '\
	set terminal pngcairo enhanced font "arial,10" size 800,600 ;\
	set output "$@" ;\
	set xlabel "samples N" ;\
	set ylabel "error" ;\
	set title "Error Comparison: Pseudo-random vs Quasi-random Monte Carlo" ;\
	plot \
	"error.data.txt" using 1:2 with lines title "Pseudo-random Error", \
	"quasierror.data.txt" using 1:2 with lines title "Quasi-random Error", \
	' | tee log.gpi | gnuplot

out.txt: main.exe
	$(RUN) $< > $@

error.data.txt: main.exe
	$(RUN) $<

linerror.data.txt: main.exe
	$(RUN) $<

main.exe: main.cs vector.dll mc.dll
	$(CSC) -reference:vector.dll -reference:mc.dll $<

vector.dll : $(COMMON_CLASSES_DIR)/vector.cs 
	$(CSC) -target:library -out:$@ $(COMMON_CLASSES_DIR)/vector.cs
	
mc.dll : mc.cs vector.dll Halton.dll
	$(CSC) -reference:vector.dll -reference:Halton.dll -target:library -out:$@ mc.cs

Halton.dll : Halton.cs
	$(CSC) -target:library -out:$@ Halton.cs

clean:
	$(RM) *.dll *.exe [Oo]ut* *.png *.txt


# ordLeastSq.dll : ordLeastSq.cs matrix.dll QRGS.dll #; $(MKLIB)
#	$(CSC) -reference:matrix.dll -reference:QRGS.dll -target:library -out:$@ ordLeastSq.cs