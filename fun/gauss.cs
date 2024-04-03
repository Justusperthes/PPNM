using System;
using System.Collections.Generic;
using System.Linq;
public class gauss{
    public static int oneBall(int depth){
        int sumsum = 0;
        for(int i=0;i<depth;i++){
            // Create a new instance of Random class
            Random random = new Random();

            // Generate a random number between 0 and 1
            int randomNumber = random.Next(0, 2); // 0 or 1

            if (randomNumber==0){
                sumsum+=1;
            }
            else{
                sumsum-=1;
            }
        }
        return sumsum;
    }
    public static List<int> gaussDist(int noOfBalls){
        List<int> listOfTargetHits = new List<int>();
        for(int i=0;i<noOfBalls;i++){
            int targetHit = oneBall(9);
            listOfTargetHits.Add(targetHit);  
        }
        listOfTargetHits = listOfTargetHits.OrderBy(x => x).ToList();
        return listOfTargetHits;
    }
    public static void PrintList(List<int> list)
    {
        Console.WriteLine("List of Hits:");
        foreach (int number in list)
        {
            Console.WriteLine(number);
        }
    }
}