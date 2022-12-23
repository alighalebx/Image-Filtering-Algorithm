using System;
using static ImageFilters.SortHelper;
using System.Collections.Generic;
using System.Text;


namespace ImageFilters
{
    class AlphaTrimFilter
    {
        public static Byte[,] ApplyFilter(Byte[,] ImageMatrix, int MaxWindowSize, int UsedAlgorithm, int TrimValue)
        {

            int width = ImageMatrix.GetLength(0);
            int height = ImageMatrix.GetLength(1);
            int trimming = TrimValue;
            int newPixelValue = 0;
            int windowSize = Math.Min(MaxWindowSize, Math.Min(height, width));
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

                            if (valid(i, j, width, height))
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
                         Kth_element(window , trimming);
                    }

                    for (int i = trimming; i < index - trimming; i++)
                    {
                        newPixelValue += window[i];
                    }

                    newPixelValue = newPixelValue / (index - trimming * 2);

                    newImage[x, y] = (Byte)newPixelValue;
                }
            }
            return newImage;
        }

        static bool valid(int i, int j, int width, int height)
        {
            if (i >= 0 && j >= 0 && i < width && j < height)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}