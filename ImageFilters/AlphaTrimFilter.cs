using System;
using System.Collections.Generic;
using System.Text;
using static ImageFilters.SortHelper;



namespace ImageFilters
{
    class AlphaTrimFilter
    {
        public static Byte[,] ApplyFilter(Byte[,] ImageMatrix, int MaxWindowSize, int UsedAlgorithm, int TrimValue)
        {
            int width = ImageMatrix.GetLength(0);
            int height = ImageMatrix.GetLength(1);


            int windowSize = Math.Min(MaxWindowSize, height);


            int trimming = TrimValue;


            Byte[,] newImage = new Byte[width, height];

            
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {

                    Byte[] window = new Byte[windowSize * windowSize];
                    int index = 0;
                    for (int i = x - windowSize / 2; i <= x + windowSize / 2; i++)
                    {
                        for (int j = y - windowSize / 2; j <= y + windowSize / 2; j++)
                        {
                            if (i >= 0 && j >= 0 && i < width && j < height)
                            {
                                window[index] = ImageMatrix[i, j];
                            }
                            index++;
                        }
                    }


                    if (UsedAlgorithm == 0)
                    {
                        CountingSort(window);
                    }
                    else
                    {
                        Kth_element(window);
                    }



                    int[] trimmedWindow = new int[windowSize * windowSize - trimming * 2];
                    Array.Copy(window, trimming, trimmedWindow, 0, windowSize * windowSize - trimming * 2);
                    int newPixelValue = 0;

                    for (int i = 0; i < trimmedWindow.Length; i++)
                    {
                        newPixelValue += trimmedWindow[i];
                    }
                    newPixelValue = newPixelValue / trimmedWindow.Length;



                    newImage[x, y] = (Byte)newPixelValue;
                }
            }
            return newImage;
        }
    }
}
