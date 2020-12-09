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
   public class Initialisation
   {
      [TestMethod]
      [ExpectedException(typeof(ArgumentException))]
      public void BufferTooShort()
      {
        var encoder = new devMobile.IoT.CayenneLpp.Encoder(0);
      }

      [TestMethod]
      [ExpectedException(typeof(ArgumentException))]
      public void BufferTooShortJust()
      {
         var encoder = new devMobile.IoT.CayenneLpp.Encoder(2);

      }

      [TestMethod]
      public void BufferLongEnough()
      {
         var encoder = new devMobile.IoT.CayenneLpp.Encoder(3);

         Assert.AreNotEqual(encoder, null);
      }

      [TestMethod]
      public void BufferNotToLong()
      {
         var encoder = new devMobile.IoT.CayenneLpp.Encoder(51);
      }

      [TestMethod]
      [ExpectedException(typeof(ArgumentException))]
      public void BufferTooLongJust()
      {
         var encoder = new devMobile.IoT.CayenneLpp.Encoder(223);
      }
   }
}
