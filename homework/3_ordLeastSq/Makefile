CODE = $(filter %.cs,$^)
LIBS = $(addprefix -reference:,$(filter %.dll,$^))
MKEXE = mcs -target:exe -out:$@ $(LIBS) $(CODE)
MKLIB = mcs -target:library -out:$@ $(LIBS) $(CODE)
COMMON_CLASSES_DIR := ../common_classes
CSC = mcs
export MONO_PATH := $(COMMON_CLASSES_DIR)
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

Plotter.dll: Plotter.cs
	$(CSC) -target:library -reference:Matrix.dll -reference:OrdLeastSq.dll -out:$@ $^

out.txt: main.exe
	$(RUN) $< > $@

main.exe: main.cs Matrix.dll OrdLeastSq.dll QRGS.dll Plotter.dll
	$(CSC) -reference:Matrix.dll -reference:OrdLeastSq.dll -reference:QRGS.dll -reference:Plotter.dll $<

Matrix.dll: $(COMMON_CLASSES_DIR)/vector.cs $(COMMON_CLASSES_DIR)/Matrix.cs ; $(MKLIB)
	$(CSC) -target:library -out:$@ $^

QRGS.dll: $(COMMON_CLASSES_DIR)/QRGS.cs Matrix.dll
	$(CSC) -reference:$(COMMON_CLASSES_DIR)/Matrix.dll -target:library -out:$@ $(COMMON_CLASSES_DIR)/QRGS.cs

OrdLeastSq.dll: OrdLeastSq.cs Matrix.dll QRGS.dll #; $(MKLIB)
	$(CSC) -reference:Matrix.dll -reference:QRGS.dll -target:library -out:$@ OrdLeastSq.cs

clean:
	$(RM) *.dll *.exe [Oo]ut*
