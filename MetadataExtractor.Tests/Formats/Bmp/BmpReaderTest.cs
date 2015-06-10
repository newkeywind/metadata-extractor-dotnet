/*
 * Copyright 2002-2015 Drew Noakes
 *
 *    Modified by Yakov Danilov <yakodani@gmail.com> for Imazen LLC (Ported from Java to C#)
 *    Licensed under the Apache License, Version 2.0 (the "License");
 *    you may not use this file except in compliance with the License.
 *    You may obtain a copy of the License at
 *
 *        http://www.apache.org/licenses/LICENSE-2.0
 *
 *    Unless required by applicable law or agreed to in writing, software
 *    distributed under the License is distributed on an "AS IS" BASIS,
 *    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 *    See the License for the specific language governing permissions and
 *    limitations under the License.
 *
 * More information about this project is available at:
 *
 *    https://drewnoakes.com/code/exif/
 *    https://github.com/drewnoakes/metadata-extractor
 */

using System.IO;
using JetBrains.Annotations;
using MetadataExtractor.Formats.Bmp;
using MetadataExtractor.IO;
using NUnit.Framework;

namespace MetadataExtractor.Tests.Formats.Bmp
{
    /// <author>Drew Noakes https://drewnoakes.com</author>
    public sealed class BmpReaderTest
    {

        [NotNull]
        public static BmpHeaderDirectory ProcessBytes([NotNull] string file)
        {
            var metadata = new Metadata();
            using (Stream stream = new FileStream(file, FileMode.Open))
            {
                new BmpReader().Extract(new SequentialStreamReader(stream), metadata);
            }
            var directory = metadata.GetFirstDirectoryOfType<BmpHeaderDirectory>();
            Assert.IsNotNull(directory);
            return directory;
        }


        [Test]
        public void TestMsPaint16Color()
        {
            var directory = ProcessBytes("Tests/Data/16color-10x10.bmp");
            Assert.IsFalse(directory.HasErrors());
            Assert.AreEqual(10, directory.GetInt(BmpHeaderDirectory.TagImageWidth));
            Assert.AreEqual(10, directory.GetInt(BmpHeaderDirectory.TagImageHeight));
            Assert.AreEqual(4, directory.GetInt(BmpHeaderDirectory.TagBitsPerPixel));
            Assert.AreEqual("None", directory.GetDescription(BmpHeaderDirectory.TagCompression));
            Assert.AreEqual(0, directory.GetInt(BmpHeaderDirectory.TagXPixelsPerMeter));
            Assert.AreEqual(0, directory.GetInt(BmpHeaderDirectory.TagYPixelsPerMeter));
            Assert.AreEqual(0, directory.GetInt(BmpHeaderDirectory.TagPaletteColourCount));
            Assert.AreEqual(0, directory.GetInt(BmpHeaderDirectory.TagImportantColourCount));
            Assert.AreEqual(1, directory.GetInt(BmpHeaderDirectory.TagColourPlanes));
            Assert.AreEqual(40, directory.GetInt(BmpHeaderDirectory.TagHeaderSize));
        }


        [Test]
        public void TestMsPaint24Bpp()
        {
            var directory = ProcessBytes("Tests/Data/24bpp-10x10.bmp");
            Assert.IsFalse(directory.HasErrors());
            Assert.AreEqual(10, directory.GetInt(BmpHeaderDirectory.TagImageWidth));
            Assert.AreEqual(10, directory.GetInt(BmpHeaderDirectory.TagImageHeight));
            Assert.AreEqual(24, directory.GetInt(BmpHeaderDirectory.TagBitsPerPixel));
            Assert.AreEqual("None", directory.GetDescription(BmpHeaderDirectory.TagCompression));
            Assert.AreEqual(0, directory.GetInt(BmpHeaderDirectory.TagXPixelsPerMeter));
            Assert.AreEqual(0, directory.GetInt(BmpHeaderDirectory.TagYPixelsPerMeter));
            Assert.AreEqual(0, directory.GetInt(BmpHeaderDirectory.TagPaletteColourCount));
            Assert.AreEqual(0, directory.GetInt(BmpHeaderDirectory.TagImportantColourCount));
            Assert.AreEqual(1, directory.GetInt(BmpHeaderDirectory.TagColourPlanes));
            Assert.AreEqual(40, directory.GetInt(BmpHeaderDirectory.TagHeaderSize));
        }
    }
}