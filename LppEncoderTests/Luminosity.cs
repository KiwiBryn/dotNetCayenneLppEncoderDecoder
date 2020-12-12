//
// Copyright (c) November 2020, devMobile Software
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
namespace devMobile.IoT.CayenneLpp
{
   using System;

   using Microsoft.VisualStudio.TestTools.UnitTesting;

   [TestClass]
   public class Luminosity
   {
      [ExpectedException(typeof(ApplicationException))]
      [TestMethod]
      public void BufferMinimumTooShortTwo()
      {
         Encoder encoder = new Encoder(7);

         encoder.LuminosityAdd(0, 1001);
         encoder.LuminosityAdd(1, 1002);
      }

      [TestMethod]
      public void BufferMinimumJustRight()
      {
         Encoder encoder = new Encoder(8);

         encoder.LuminosityAdd(0, 1003);
         encoder.LuminosityAdd(1, 1004);
      }

      [TestMethod]
      public void BufferMinimumTooLong()
      {
         Encoder encoder = new Encoder(9);

         encoder.TemperatureAdd(0, 1005);
         encoder.TemperatureAdd(1, 1006);
      }

      [TestMethod]
      public void OnlyOneZero()
      {
         Encoder encoder = new Encoder(4);

         encoder.LuminosityAdd(0, 0);

         string bcdText = encoder.Bcd();

         Assert.AreEqual(8, bcdText.Length);

         Assert.AreEqual("00650000", bcdText);
      }

      [TestMethod]
      public void ChannelMinimum()
      {
         Encoder encoder = new Encoder(4);

         encoder.LuminosityAdd(0, 1230);

         string bcdText = encoder.Bcd();

         Assert.AreEqual("006504CE".Replace(" ", ""), bcdText);
      }

      [TestMethod]
      public void ChannelMaximum()
      {
         Encoder encoder = new Encoder(4);

         encoder.LuminosityAdd(64, 1234);

         string bcdText = encoder.Bcd();

         Assert.AreEqual("406504D2".Replace(" ", ""), bcdText);
      }

      [ExpectedException(typeof(ArgumentException))]
      [TestMethod]
      public void ChannelTooLarge()
      {
         Encoder encoder = new Encoder(4);

         encoder.LuminosityAdd(65, 1234);
      }
   }
}
