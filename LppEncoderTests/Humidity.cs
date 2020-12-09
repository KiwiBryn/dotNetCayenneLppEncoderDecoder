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
   public class Humidity
   {
      [TestMethod]
      public void OnlyOneZero()
      {
         Encoder encoder = new Encoder(3);

         encoder.RelativeHumidityAdd(0, 0.0f);

         string bcdText = encoder.Bcd();

         Assert.AreEqual(6, bcdText.Length);

         Assert.AreEqual("006800", bcdText);
      }
      /*
      [TestMethod]
      public void MyDevicesExampleOneHumidity()
      {
         Encoder encoder = new Encoder(51);

         encoder.RelativeHumidityAdd(1, 0.0);

         string bcdText = encoder.Bcd();

         Assert.AreEqual(8, bcdText.Length);

         Assert.AreEqual("0167FFD7", bcdText);
      }

      [TestMethod]
      public void MyDevicesExampleTwoHumidities()
      {
         Encoder encoder = new Encoder(51);

         encoder.TemperatureAdd(3, 27.2f);
         encoder.TemperatureAdd(5, 25.5f);

         string bcdText = encoder.Bcd();

         Assert.AreEqual(16, bcdText.Length);

         Assert.AreEqual("03670110056700FF", bcdText);
      }

      [TestMethod]
      public void OnlyOne()
      {
         Encoder encoder = new Encoder(3);

         encoder.TemperatureAdd(0, true);

         string bcdText = encoder.Bcd();

         Assert.AreEqual(bcdText.Length, 6);

         Assert.AreEqual("000001", bcdText);
      }


      [TestMethod]
      public void OnlyOneFalse()
      {
         Encoder encoder = new Encoder(3);

         encoder.TemperatureAdd(0, false);

         string bcdText = encoder.Bcd();

         Assert.AreEqual(bcdText.Length, 6);

         Assert.AreEqual("000000", bcdText);
      }

      [ExpectedException(typeof(ApplicationException))]
      [TestMethod]
      public void BufferMinimumTooShortTwo()
      {
         Encoder encoder = new Encoder(7);

         encoder.TemperatureAdd(0, 1.23f);
         encoder.TemperatureAdd(1, 4.56f);
      }

      [TestMethod]
      public void TwoTrue()
      {
         Encoder encoder = new Encoder(6);

         encoder.TemperatureAdd(0, true);
         encoder.TemperatureAdd(5, true);

         string bcdText = encoder.Bcd();

         Assert.AreEqual(bcdText.Length, 12);

         Assert.AreEqual("000001050001", bcdText);
      }

      [TestMethod]
      public void TwoTrueFalse()
      {
         Encoder encoder = new Encoder(6);

         encoder.TemperatureAdd(0, true);
         encoder.TemperatureAdd(1, false);

         string bcdText = encoder.Bcd();

         Assert.AreEqual(bcdText.Length, 12);

         Assert.AreEqual("000001010000", bcdText);
      }


      [TestMethod]
      public void TwoFalse()
      {
         Encoder encoder = new Encoder(6);

         encoder.TemperatureAdd(0, false);
         encoder.TemperatureAdd(1, false);

         string bcdText = encoder.Bcd();

         Assert.AreEqual(bcdText.Length, 12);

         Assert.AreEqual("000000010000", bcdText);
      }

      [TestMethod]
      public void TwoFalseTrue()
      {
         Encoder encoder = new Encoder(6);

         encoder.TemperatureAdd(0, false);
         encoder.TemperatureAdd(1, true);

         string bcdText = encoder.Bcd();

         Assert.AreEqual(bcdText.Length, 12);

         Assert.AreEqual("000000010001", bcdText);
      }

      [ExpectedException(typeof(ApplicationException))]
      [TestMethod]
      public void BufferMinimumTooLong()
      {
         Encoder encoder = new Encoder(3);

         encoder.TemperatureAdd(0, true);
         encoder.DigitalInputAdd(1, true);
      }

      [TestMethod]
      public void BufferMaximum()
      {
         Encoder encoder = new Encoder(51);

         encoder.TemperatureAdd(0, true);
         encoder.TemperatureAdd(1, true);
         encoder.TemperatureAdd(2, true);
         encoder.TemperatureAdd(3, true);
         encoder.TemperatureAdd(4, true);

         encoder.TemperatureAdd(6, true);
         encoder.TemperatureAdd(6, true);
         encoder.TemperatureAdd(7, true);
         encoder.TemperatureAdd(8, true);
         encoder.TemperatureAdd(9, true);

         encoder.TemperatureAdd(10, true);
         encoder.TemperatureAdd(11, true);
         encoder.TemperatureAdd(12, true);
         encoder.TemperatureAdd(13, true);
         encoder.TemperatureAdd(14, true);

         encoder.TemperatureAdd(15, true);
         encoder.TemperatureAdd(16, true);
      }

      [ExpectedException(typeof(ApplicationException))]
      [TestMethod]
      public void BufferMaximumTooLong()
      {
         Encoder encoder = new Encoder(51);

         encoder.TemperatureAdd(0, true);
         encoder.TemperatureAdd(1, true);
         encoder.TemperatureAdd(2, true);
         encoder.TemperatureAdd(3, true);
         encoder.TemperatureAdd(4, true);

         encoder.TemperatureAdd(6, true);
         encoder.TemperatureAdd(6, true);
         encoder.TemperatureAdd(7, true);
         encoder.TemperatureAdd(8, true);
         encoder.TemperatureAdd(9, true);

         encoder.TemperatureAdd(10, true);
         encoder.TemperatureAdd(11, true);
         encoder.TemperatureAdd(12, true);
         encoder.TemperatureAdd(13, true);
         encoder.TemperatureAdd(14, true);

         encoder.TemperatureAdd(15, true);
         encoder.TemperatureAdd(16, true);
         encoder.TemperatureAdd(17, true);
         encoder.TemperatureAdd(18, true);
         encoder.TemperatureAdd(19, true);

         encoder.TemperatureAdd(20, true);
         encoder.TemperatureAdd(21, true);
         encoder.TemperatureAdd(22, true);
      }
   */
      /*
      [TestMethod]
      public void ChannelMinimum()
      {
         Encoder encoder = new Encoder(3);
         encoder.DigitalInputAdd(0, true);
      }

      [TestMethod]
      public void ChannelMaximum()
      {
         Encoder encoder = new Encoder(3);
         encoder.DigitalInputAdd(64, true);

         string bcdText = encoder.Bcd();

         Assert.AreEqual("400001", bcdText);
      }

      [ExpectedException(typeof(ArgumentException))]
      [TestMethod]
      public void ChannelToLarge()
      {
         Encoder encoder = new Encoder(3);

         encoder.TemperatureAdd(65, 0.0f);
      }
      */
   }
}