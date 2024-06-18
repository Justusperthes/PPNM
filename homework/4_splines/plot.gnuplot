
        set terminal pngcairo enhanced
        set output 'c_cos_plot.png'
        set title 'C Interpolation of Cos(x)'
        set xlabel 'X'
        set ylabel 'Y'
        plot 'c_data.dat' with points pointtype 7 pointsize 1.5 linecolor 'blue' title 'Original Data', \
             'c_interp_data.dat' with lines linecolor 'red' title 'Interpolated Data'
        
