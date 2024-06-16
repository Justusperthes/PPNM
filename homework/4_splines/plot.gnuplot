
        set terminal pngcairo enhanced
        set output 'combined_plot.png'
        set title 'Data Points'
        set xlabel 'X'
        set ylabel 'Y'
        plot 'data.dat' with points pointtype 7 pointsize 1.5 linecolor 'blue' title 'Original Data', \
             'interp_data.dat' with lines linecolor 'red' title 'Interpolated Data'
        
