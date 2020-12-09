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
   public class Temperature
   {
      [ExpectedException(typeof(ApplicationException))]
      [TestMethod]
      public void BufferMinimumTooShortTwo()
      {
         Encoder encoder = new Encoder(7);

         encoder.TemperatureAdd(0, 1.23f);
         encoder.TemperatureAdd(1, 4.56f);
      }

      [TestMethod]
      public void BufferMinimumJustRight()
      {
         Encoder encoder = new Encoder(8);

         encoder.TemperatureAdd(0, 1.23f);
         encoder.TemperatureAdd(1, 4.56f);
      }

      [TestMethod]
      public void BufferMinimumTooLong()
      {
         Encoder encoder = new Encoder(9);

         encoder.TemperatureAdd(0, 1.23f);
         encoder.TemperatureAdd(1, 4.56f);
      }

      [TestMethod]
      public void MyDevicesExampleOneTemperature()
      {
         Encoder encoder = new Encoder(51);

         encoder.TemperatureAdd(1, -4.1f);

         string bcdText = encoder.Bcd();

         Assert.AreEqual(8, bcdText.Length);

         Assert.AreEqual("0167FFD7", bcdText);
      }

      [TestMethod]
      public void MyDevicesExampleTwoTemperatures()
      {
         Encoder encoder = new Encoder(51);

         encoder.TemperatureAdd(3, 27.2f);
         encoder.TemperatureAdd(5, 25.5f);

         string bcdText = encoder.Bcd();

         Assert.AreEqual(16, bcdText.Length);

         Assert.AreEqual("03670110056700FF", bcdText);
      }

      [TestMethod]
      public void ZeroValue()
      {
         Encoder encoder = new Encoder(51);
         string bcdText;

         encoder.TemperatureAdd(0,0);
         bcdText = encoder.Bcd();

         Assert.AreEqual(8, bcdText.Length);
         Assert.AreEqual("00670000", bcdText);
      }

      [TestMethod]
      public void ZerothPositiveValues()
      {
         Encoder encoder = new Encoder(51);
         string bcdText;

         encoder.TemperatureAdd(0, 0.0f);
         encoder.TemperatureAdd(1, 0.1f);
         encoder.TemperatureAdd(2, 0.2f);
         encoder.TemperatureAdd(3, 0.3f);
         encoder.TemperatureAdd(4, 0.4f);
         encoder.TemperatureAdd(5, 0.5f);
         encoder.TemperatureAdd(6, 0.6f);
         encoder.TemperatureAdd(7, 0.7f);
         encoder.TemperatureAdd(8, 0.8f);
         encoder.TemperatureAdd(9, 0.9f);
         bcdText = encoder.Bcd();

         Assert.AreEqual(80, bcdText.Length);
         Assert.AreEqual("00670000 01670001 02670002 03670003 04670004 05670005 06670006 07670007 08670008 09670009".Replace(" ",""), bcdText);
      }

      [TestMethod]
      public void ZerothPositiveValuesRounding()
      {
         Encoder encoder = new Encoder(51);
         string bcdText;

         encoder.TemperatureAdd(0, 0.10f);
         encoder.TemperatureAdd(1, 0.11f);
         encoder.TemperatureAdd(2, 0.12f);
         encoder.TemperatureAdd(3, 0.13f);
         encoder.TemperatureAdd(4, 0.14f);
         encoder.TemperatureAdd(5, 0.15f);
         encoder.TemperatureAdd(6, 0.16f);
         encoder.TemperatureAdd(7, 0.17f);
         encoder.TemperatureAdd(8, 0.18f);
         encoder.TemperatureAdd(9, 0.19f);
         bcdText = encoder.Bcd();

         Assert.AreEqual(80, bcdText.Length);
         Assert.AreEqual("00670001 01670001 02670001 03670001 04670001 05670002 06670002 07670002 08670002 09670002".Replace(" ", ""), bcdText);
      }
      
      [TestMethod]
      public void ZerothNegativeValues()
      {
         Encoder encoder = new Encoder(51);
         string bcdText;

         encoder.TemperatureAdd(0, 0.0f);
         encoder.TemperatureAdd(1, -0.1f);
         encoder.TemperatureAdd(2, -0.2f);
         encoder.TemperatureAdd(3, -0.3f);
         encoder.TemperatureAdd(4, -0.4f);
         encoder.TemperatureAdd(5, -0.5f);
         encoder.TemperatureAdd(6, -0.6f);
         encoder.TemperatureAdd(7, -0.7f);
         encoder.TemperatureAdd(8, -0.8f);
         encoder.TemperatureAdd(9, -0.9f);
         bcdText = encoder.Bcd();

         Assert.AreEqual(80, bcdText.Length);
         Assert.AreEqual("00670000 0167FFFF 0267FFFE 0367FFFD 0467FFFC 0567FFFB 0667FFFA 0767FFF9 0867FFF8 0967FFF7".Replace(" ", ""), bcdText);
      }

      [TestMethod]
      public void ZerothNegativeValuesRounding()
      {
         Encoder encoder = new Encoder(51);
         string bcdText;

         encoder.TemperatureAdd(0, 0.0f);
         encoder.TemperatureAdd(1, -0.1f);
         encoder.TemperatureAdd(2, -0.12f);
         encoder.TemperatureAdd(3, -0.13f);
         encoder.TemperatureAdd(4, -0.14f);
         encoder.TemperatureAdd(5, -0.15f);
         encoder.TemperatureAdd(6, -0.16f);
         encoder.TemperatureAdd(7, -0.17f);
         encoder.TemperatureAdd(8, -0.18f);
         encoder.TemperatureAdd(9, -0.19f);
         bcdText = encoder.Bcd();

         Assert.AreEqual(80, bcdText.Length);
         Assert.AreEqual("00670000 0167FFFF 0267FFFF 0367FFFF 0467FFFF 0567FFFE 0667FFFE 0767FFFE 0867FFFE 0967FFFE".Replace(" ", ""), bcdText);
      }

      [TestMethod]
      public void ChannelMinimum()
      {
         Encoder encoder = new Encoder(4);

         encoder.TemperatureAdd(0, 1.23f);

         string bcdText = encoder.Bcd();

         Assert.AreEqual("0067000C".Replace(" ", ""), bcdText);
      }

      [TestMethod]
      public void ChannelMaximum()
      {
         Encoder encoder = new Encoder(4);

         encoder.TemperatureAdd(64, 1.23f);

         string bcdText = encoder.Bcd();

         Assert.AreEqual("4067000C".Replace(" ", ""), bcdText);
      }

      [ExpectedException(typeof(ArgumentException))]
      [TestMethod]
      public void ChannelTooLarge()
      {
         Encoder encoder = new Encoder(4);

         encoder.TemperatureAdd(65, 0.0f);
      }
   }
}