
        set terminal pngcairo enhanced
        set output 'q_cos_plot.png'
        set title 'Q Interpolation of Cos(x)'
        set xlabel 'X'
        set ylabel 'Y'
        plot 'q_data.dat' with points pointtype 7 pointsize 1.5 linecolor 'blue' title 'Original Data', \
             'q_interp_data.dat' with lines linecolor 'red' title 'Interpolated Data'
        
