using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using static ImageFilters.SortHelper;

namespace ImageFilters
{
    class AdaptiveMedianFilter
    {

        public static Byte[,] ApplyFilter(Byte[,] ImageMatrix, int MaxWindowSize, int UsedAlgorithm)
        {
            //TODO: Implement adaptive median filter
            // For each pixel in the image:
            // 0) Start by window size 3×3

            // 0 0 1
            // 2 4 40
            //255 6 20


            // 0 0 1 2 4 6 20 40 255
            // A1 = 4 - 0 = 4
            // A2 = 255 - 4 = 251 
            // tayb kda el A1 w A2 akabr mn el 0 fa el point non-noise median hnro7 l step 2
            // else hnkabar el size bta3 el window el w5dnha el hya mn el 25r el (W) bs kda
            // step 2 h7sb el B1 w B2  
            // B1 = el point el kona msknha - el min = 4- 0 = 4
            // B2 = el max - el point el kona msknha fy el 2wl msh el median  = 255 - 4 = 251 
            // tayb bma hna byb2a 3ndna 7lteen y3ny if else mn el 25r lw el rakam bta3 el B1 w B2 akabar mn 0 yb2a el new pixel = el point el 25trnaha 
            // else el new pixel = el median bs kda
            // w nrga3 step 0 tani
            //int width = ImageMatrix.GetLength(0);
            //int height = ImageMatrix.GetLength(1);


            //int windowSize = Math.Min(MaxWindowSize, height);


            //Byte[,] newImage = new Byte[width, height];

            //for (int x = 0; x < width; x++)
            //{
            //    for (int y = 0; y < height; y++)
            //    {

            //        Byte[] window = new Byte[windowSize * windowSize];
            //        int index = 0;
            //        for (int i = x - windowSize / 2; i <= x + windowSize / 2; i++)
            //        {
            //            for (int j = y - windowSize / 2; j <= y + windowSize / 2; j++)
            //            {
            //                if (i >= 0 && j >= 0 && i < width && j < height)
            //                {
            //                    window[index] = ImageMatrix[i, j];
            //                }

            //                index++;
            //            }
            //        }


            //        if (UsedAlgorithm == 0)
            //        {
            //            CountingSort(window);
            //        }
            //        else
            //        {
            //            QuickSort(window);
            //        }

            //        // 1) Chose a non-noise median value (true median)
            //        // 2) Replace the center with the median value if not noise, or leave it and move to the next pixel
            //        // 3) Repeat the process for the next pixel starting from step 0 again
            //        //7aga
            //        // Remove the next line

            //    }
            //}
            //throw new NotImplementedException();
            int width = ImageMatrix.GetLength(0);
            int height = ImageMatrix.GetLength(1);
            
            Byte[,] newImage = new Byte[width, height];

            
                for (int x = 0; x < width; x++)
                {
                    for (int y = 0; y < height; y++)
                    {
                    //if (newImage[x, y] == 0 || newImage[x, y] == 255)
                    //{
                    //    continue;
                    //}
                    int windowsize = 3;

                        int newpixel=-1;
                            while (windowsize <= MaxWindowSize)
                            {

                                Byte[] window = new Byte[windowsize * windowsize];
                        int index = 0;
                        for (int i = x - windowsize / 2; i <= x + windowsize / 2; i++)
                        {
                            for (int j = y - windowsize / 2; j <= y + windowsize / 2; j++)
                            {
                                if (i >= 0 && j >= 0 && i < width && j < height)
                                {
                                    window[index] = ImageMatrix[i, j];
                                }

                                index++;
                            }
                        }

                        int size = index;
                        int mid = size / 2;
                        int midBeforeSort = window[mid];
                        if (UsedAlgorithm == 0)
                        {
                            Array.Sort(window);
                        }
                        else
                        {
                            CountingSort(window);
                        }

                        int zmed = window[mid];
                        int zmin = window[0];
                        newpixel = zmed;
                        
                        int zmax = window[size - 1];
                        int a1 = zmed - zmin;
                        int a2 = zmax - zmed;
                        if (a1 > 0 && a2 > 0)
                        {
                            int b1 = midBeforeSort - zmin;
                            int b2 = zmax - midBeforeSort;
                            if (b1 > 0 && b2 > 0)
                            {
                                newpixel = midBeforeSort;
                            }
                            else
                            {
                                newpixel = zmed;
                            }
                            break;
                        }

                        // windowsize = windowsize + 2;
                        windowsize += 2;
                            
                            
                        

                     



                    } Debug.Assert(newpixel >= 0);

                    newImage[x, y] = (Byte)newpixel;

                }


            }

            return newImage;

        }
    }
}