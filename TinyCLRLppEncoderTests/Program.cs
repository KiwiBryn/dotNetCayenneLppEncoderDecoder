﻿//
// Copyright (c) October 2020, devMobile Software
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
namespace devMobile.IoT.CayenneLpp.TinyCLRLppEncoderTests
{
   using System.Diagnostics;

   public class Program
   {
      public static void Main()
      {
         Debug.WriteLine("devMobile.IoT.CayenneLpp.TinyCLRLppEncoderTests starting");

         Encoder encoder = new Encoder(51);

         encoder.GpsLocationAdd(1, 42.3519f, -87.9094f, 10.0f);

         string bcdText = encoder.Bcd();

         Debug.Assert(22 == bcdText.Length, "Invalid BCD payload length");

         Debug.Assert("018806765FF2960A0003E8" == bcdText, "Invalid BCD payload");
      }
   }
}
