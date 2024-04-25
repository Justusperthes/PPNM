CODE = $(filter %.cs,$^)
LIBS = $(addprefix -reference:,$(filter %.dll,$^))
MKEXE = mcs -target:exe -out:$@ $(LIBS) $(CODE)
MKLIB = mcs -target:library -out:$@ $(LIBS) $(CODE)
CSC = mcs
RUN = mono --debug

all: error.gnuplot.png linerror.gnuplot.png out.txt
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

out.txt: main.exe
	$(RUN) $< > $@

error.data.txt: main.exe
	$(RUN) $<

linerror.data.txt: main.exe
	$(RUN) $<

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


# ordLeastSq.dll : ordLeastSq.cs matrix.dll QRGS.dll #; $(MKLIB)
#	$(CSC) -reference:matrix.dll -reference:QRGS.dll -target:library -out:$@ ordLeastSq.cs