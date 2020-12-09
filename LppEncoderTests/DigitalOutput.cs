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
   public class DigitalOutput
   {
      [TestMethod]
      public void OnlyOneTrue()
      {
         Encoder encoder = new Encoder(3);

         encoder.DigitalOutputAdd(0, true);

         string bcdText = encoder.Bcd();

         Assert.AreEqual(bcdText.Length, 6);

         Assert.AreEqual("000101", bcdText);
      }

      [TestMethod]
      public void OnlyOneFalse()
      {
         Encoder encoder = new Encoder(3);

         encoder.DigitalOutputAdd(0, false);

         string bcdText = encoder.Bcd();

         Assert.AreEqual(bcdText.Length, 6);

         Assert.AreEqual("000100", bcdText);
      }

      [ExpectedException(typeof(ApplicationException))]
      [TestMethod]
      public void BufferMinimumTooShortTwo()
      {
         Encoder encoder = new Encoder(3);

         encoder.DigitalOutputAdd(0, true);
         encoder.DigitalOutputAdd(1, true);
      }

      [TestMethod]
      public void TwoTrue()
      {
         Encoder encoder = new Encoder(6);

         encoder.DigitalOutputAdd(0, true);
         encoder.DigitalOutputAdd(1, true);

         string bcdText = encoder.Bcd();

         Assert.AreEqual(bcdText.Length, 12);

         Assert.AreEqual("000101010101", bcdText);
      }

      [TestMethod]
      public void TwoTrueFalse()
      {
         Encoder encoder = new Encoder(6);

         encoder.DigitalOutputAdd(0, true);
         encoder.DigitalOutputAdd(1, false);

         string bcdText = encoder.Bcd();

         Assert.AreEqual(bcdText.Length, 12);

         Assert.AreEqual("000101010100", bcdText);
      }

      [TestMethod]
      public void TwoFalse()
      {
         Encoder encoder = new Encoder(6);

         encoder.DigitalOutputAdd(0, false);
         encoder.DigitalOutputAdd(1, false);

         string bcdText = encoder.Bcd();

         Assert.AreEqual(bcdText.Length, 12);

         Assert.AreEqual("000100010100", bcdText);
      }

      [TestMethod]
      public void TwoFalseTrue()
      {
         Encoder encoder = new Encoder(6);

         encoder.DigitalOutputAdd(0, false);
         encoder.DigitalOutputAdd(1, true);

         string bcdText = encoder.Bcd();

         Assert.AreEqual(bcdText.Length, 12);

         Assert.AreEqual("000100010101", bcdText);
      }

      [ExpectedException(typeof(ApplicationException))]
      [TestMethod]
      public void BufferMinimumTooLong()
      {
         Encoder encoder = new Encoder(3);

         encoder.DigitalOutputAdd(0, true);
         encoder.DigitalOutputAdd(1, true);
      }

      [TestMethod]
      public void BufferMaximum()
      {
         Encoder encoder = new Encoder(51);

         encoder.DigitalOutputAdd(0, true);
         encoder.DigitalOutputAdd(1, true);
         encoder.DigitalOutputAdd(2, true);
         encoder.DigitalOutputAdd(3, true);
         encoder.DigitalOutputAdd(4, true);

         encoder.DigitalOutputAdd(6, true);
         encoder.DigitalOutputAdd(6, true);
         encoder.DigitalOutputAdd(7, true);
         encoder.DigitalOutputAdd(8, true);
         encoder.DigitalOutputAdd(9, true);

         encoder.DigitalOutputAdd(10, true);
         encoder.DigitalOutputAdd(11, true);
         encoder.DigitalOutputAdd(12, true);
         encoder.DigitalOutputAdd(13, true);
         encoder.DigitalOutputAdd(14, true);

         encoder.DigitalOutputAdd(15, true);
         encoder.DigitalOutputAdd(16, true);
      }

      [ExpectedException(typeof(ApplicationException))]
      [TestMethod]
      public void BufferMaximumTooLong()
      {
         Encoder encoder = new Encoder(51);

         encoder.DigitalOutputAdd(0, true);
         encoder.DigitalOutputAdd(1, true);
         encoder.DigitalOutputAdd(2, true);
         encoder.DigitalOutputAdd(3, true);
         encoder.DigitalOutputAdd(4, true);

         encoder.DigitalOutputAdd(6, true);
         encoder.DigitalOutputAdd(6, true);
         encoder.DigitalOutputAdd(7, true);
         encoder.DigitalOutputAdd(8, true);
         encoder.DigitalOutputAdd(9, true);

         encoder.DigitalOutputAdd(10, true);
         encoder.DigitalOutputAdd(11, true);
         encoder.DigitalOutputAdd(12, true);
         encoder.DigitalOutputAdd(13, true);
         encoder.DigitalOutputAdd(14, true);

         encoder.DigitalOutputAdd(15, true);
         encoder.DigitalOutputAdd(16, true);
         encoder.DigitalOutputAdd(17, true);
         encoder.DigitalOutputAdd(18, true);
         encoder.DigitalOutputAdd(19, true);

         encoder.DigitalOutputAdd(20, true);
         encoder.DigitalOutputAdd(21, true);
         encoder.DigitalOutputAdd(22, true);
      }

      [TestMethod]
      public void ChannelMinimum()
      {
         Encoder encoder = new Encoder(3);

         encoder.DigitalOutputAdd(0, true);
      }

      [TestMethod]
      public void ChannelMaximum()
      {
         Encoder encoder = new Encoder(3);

         encoder.DigitalOutputAdd(64, true);
      }

      [ExpectedException(typeof(ArgumentException))]
      [TestMethod]
      public void ChannelToLarge()
      {
         Encoder encoder = new Encoder(3);

         encoder.DigitalOutputAdd(65, true);
      }
   }
}
