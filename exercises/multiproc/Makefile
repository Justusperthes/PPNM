CODE = $(filter %.cs,$^)
LIBS = $(addprefix -reference:,$(filter %.dll,$^))
MKEXE = mcs -target:exe -out:$@ $(LIBS) $(CODE)
MKLIB = mcs -target:library -out:$@ $(LIBS) $(CODE)
TIME = time --output=$@ --append --format "$$nthreads %e %U"

main.exe : main.cs ; $

Out.times.svg : out.times.txt Makefile
	echo '\
		set terminal svg background "white" ;\
		set out "$@" ;\
		plot "$<" with lp ;\
		'| tee log.gpi | gnuplot

N = 2e8
out.times.txt : main.exe
	for nthreads in 1 2 3 4; do\
		$(TIME) mono main.exe .nthreads:$$nthreads -nterms:$(N); \
	done
