using System;
using System.Collections.Generic;

namespace Task01
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Cookie> cookies = new List<Cookie>() {
                new Cookie(15, "round", new int[3] {255, 255, 255}, "black"),
                new Cookie(28, "elliptical", new int[3] {255, 255, 255}, "black"),
                new Cookie(13, "square", new int[3] {0, 0, 0}, "white"),
                new Cookie(24, "rectangular", new int[3] {0, 0, 0}, "white"),
            };

            foreach(Cookie cookie in cookies) {
                System.Console.WriteLine($"Weight: {cookie.weight}, Shape: {cookie.shape}, Colour: {cookie.color.name}, RGB: ({cookie.color.rgb[0]},{cookie.color.rgb[1]},{cookie.color.rgb[2]})");
            }
        }
    }
}
