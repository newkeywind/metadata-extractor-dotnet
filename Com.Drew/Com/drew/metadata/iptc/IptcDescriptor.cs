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

using Com.Drew.Lang;
using JetBrains.Annotations;
using Sharpen;

namespace Com.Drew.Metadata.Iptc
{
    /// <summary>
    /// Provides human-readable string representations of tag values stored in a <see cref="IptcDirectory"/>.
    /// <para>
    /// As the IPTC directory already stores values as strings, this class simply returns the tag's value.
    /// </summary>
    /// <author>Drew Noakes https://drewnoakes.com</author>
    public class IptcDescriptor : TagDescriptor<IptcDirectory>
    {
        public IptcDescriptor([NotNull] IptcDirectory directory)
            : base(directory)
        {
        }

        [CanBeNull]
        public override string GetDescription(int tagType)
        {
            switch (tagType)
            {
                case IptcDirectory.TagFileFormat:
                {
                    return GetFileFormatDescription();
                }

                case IptcDirectory.TagKeywords:
                {
                    return GetKeywordsDescription();
                }

                case IptcDirectory.TagTimeCreated:
                {
                    return GetTimeCreatedDescription();
                }

                case IptcDirectory.TagDigitalTimeCreated:
                {
                    return GetDigitalTimeCreatedDescription();
                }

                default:
                {
                    return base.GetDescription(tagType);
                }
            }
        }

        [CanBeNull]
        public virtual string GetFileFormatDescription()
        {
            int? value = Directory.GetInteger(IptcDirectory.TagFileFormat);
            if (value == null)
            {
                return null;
            }
            switch (value)
            {
                case 0:
                {
                    return "No ObjectData";
                }

                case 1:
                {
                    return "IPTC-NAA Digital Newsphoto Parameter Record";
                }

                case 2:
                {
                    return "IPTC7901 Recommended Message Format";
                }

                case 3:
                {
                    return "Tagged Image File Format (Adobe/Aldus Image data)";
                }

                case 4:
                {
                    return "Illustrator (Adobe Graphics data)";
                }

                case 5:
                {
                    return "AppleSingle (Apple Computer Inc)";
                }

                case 6:
                {
                    return "NAA 89-3 (ANPA 1312)";
                }

                case 7:
                {
                    return "MacBinary II";
                }

                case 8:
                {
                    return "IPTC Unstructured Character Oriented File Format (UCOFF)";
                }

                case 9:
                {
                    return "United Press International ANPA 1312 variant";
                }

                case 10:
                {
                    return "United Press International Down-Load Message";
                }

                case 11:
                {
                    return "JPEG File Interchange (JFIF)";
                }

                case 12:
                {
                    return "Photo-CD Image-Pac (Eastman Kodak)";
                }

                case 13:
                {
                    return "Bit Mapped Graphics File [.BMP] (Microsoft)";
                }

                case 14:
                {
                    return "Digital Audio File [.WAV] (Microsoft & Creative Labs)";
                }

                case 15:
                {
                    return "Audio plus Moving Video [.AVI] (Microsoft)";
                }

                case 16:
                {
                    return "PC DOS/Windows Executable Files [.COM][.EXE]";
                }

                case 17:
                {
                    return "Compressed Binary File [.ZIP] (PKWare Inc)";
                }

                case 18:
                {
                    return "Audio Interchange File Format AIFF (Apple Computer Inc)";
                }

                case 19:
                {
                    return "RIFF Wave (Microsoft Corporation)";
                }

                case 20:
                {
                    return "Freehand (Macromedia/Aldus)";
                }

                case 21:
                {
                    return "Hypertext Markup Language [.HTML] (The Internet Society)";
                }

                case 22:
                {
                    return "MPEG 2 Audio Layer 2 (Musicom), ISO/IEC";
                }

                case 23:
                {
                    return "MPEG 2 Audio Layer 3, ISO/IEC";
                }

                case 24:
                {
                    return "Portable Document File [.PDF] Adobe";
                }

                case 25:
                {
                    return "News Industry Text Format (NITF)";
                }

                case 26:
                {
                    return "Tape Archive [.TAR]";
                }

                case 27:
                {
                    return "Tidningarnas Telegrambyra NITF version (TTNITF DTD)";
                }

                case 28:
                {
                    return "Ritzaus Bureau NITF version (RBNITF DTD)";
                }

                case 29:
                {
                    return "Corel Draw [.CDR]";
                }
            }
            return Extensions.StringFormat("Unknown (%d)", value);
        }

        [CanBeNull]
        public virtual string GetByLineDescription()
        {
            return Directory.GetString(IptcDirectory.TagByLine);
        }

        [CanBeNull]
        public virtual string GetByLineTitleDescription()
        {
            return Directory.GetString(IptcDirectory.TagByLineTitle);
        }

        [CanBeNull]
        public virtual string GetCaptionDescription()
        {
            return Directory.GetString(IptcDirectory.TagCaption);
        }

        [CanBeNull]
        public virtual string GetCategoryDescription()
        {
            return Directory.GetString(IptcDirectory.TagCategory);
        }

        [CanBeNull]
        public virtual string GetCityDescription()
        {
            return Directory.GetString(IptcDirectory.TagCity);
        }

        [CanBeNull]
        public virtual string GetCopyrightNoticeDescription()
        {
            return Directory.GetString(IptcDirectory.TagCopyrightNotice);
        }

        [CanBeNull]
        public virtual string GetCountryOrPrimaryLocationDescription()
        {
            return Directory.GetString(IptcDirectory.TagCountryOrPrimaryLocationName);
        }

        [CanBeNull]
        public virtual string GetCreditDescription()
        {
            return Directory.GetString(IptcDirectory.TagCredit);
        }

        [CanBeNull]
        public virtual string GetDateCreatedDescription()
        {
            return Directory.GetString(IptcDirectory.TagDateCreated);
        }

        [CanBeNull]
        public virtual string GetHeadlineDescription()
        {
            return Directory.GetString(IptcDirectory.TagHeadline);
        }

        [CanBeNull]
        public virtual string GetKeywordsDescription()
        {
            string[] keywords = Directory.GetStringArray(IptcDirectory.TagKeywords);
            if (keywords == null)
            {
                return null;
            }
            return StringUtil.Join(keywords.ToCharSequence(), ";");
        }

        [CanBeNull]
        public virtual string GetObjectNameDescription()
        {
            return Directory.GetString(IptcDirectory.TagObjectName);
        }

        [CanBeNull]
        public virtual string GetOriginalTransmissionReferenceDescription()
        {
            return Directory.GetString(IptcDirectory.TagOriginalTransmissionReference);
        }

        [CanBeNull]
        public virtual string GetOriginatingProgramDescription()
        {
            return Directory.GetString(IptcDirectory.TagOriginatingProgram);
        }

        [CanBeNull]
        public virtual string GetProvinceOrStateDescription()
        {
            return Directory.GetString(IptcDirectory.TagProvinceOrState);
        }

        [CanBeNull]
        public virtual string GetRecordVersionDescription()
        {
            return Directory.GetString(IptcDirectory.TagApplicationRecordVersion);
        }

        [CanBeNull]
        public virtual string GetReleaseDateDescription()
        {
            return Directory.GetString(IptcDirectory.TagReleaseDate);
        }

        [CanBeNull]
        public virtual string GetReleaseTimeDescription()
        {
            return Directory.GetString(IptcDirectory.TagReleaseTime);
        }

        [CanBeNull]
        public virtual string GetSourceDescription()
        {
            return Directory.GetString(IptcDirectory.TagSource);
        }

        [CanBeNull]
        public virtual string GetSpecialInstructionsDescription()
        {
            return Directory.GetString(IptcDirectory.TagSpecialInstructions);
        }

        [CanBeNull]
        public virtual string GetSupplementalCategoriesDescription()
        {
            return Directory.GetString(IptcDirectory.TagSupplementalCategories);
        }

        [CanBeNull]
        public virtual string GetTimeCreatedDescription()
        {
            string s = Directory.GetString(IptcDirectory.TagTimeCreated);
            if (s == null)
            {
                return null;
            }
            if (s.Length == 6 || s.Length == 11)
            {
                return Runtime.Substring(s, 0, 2) + ':' + Runtime.Substring(s, 2, 4) + ':' + Runtime.Substring(s, 4);
            }
            return s;
        }

        [CanBeNull]
        public virtual string GetDigitalTimeCreatedDescription()
        {
            string s = Directory.GetString(IptcDirectory.TagDigitalTimeCreated);
            if (s == null)
            {
                return null;
            }
            if (s.Length == 6 || s.Length == 11)
            {
                return Runtime.Substring(s, 0, 2) + ':' + Runtime.Substring(s, 2, 4) + ':' + Runtime.Substring(s, 4);
            }
            return s;
        }

        [CanBeNull]
        public virtual string GetUrgencyDescription()
        {
            return Directory.GetString(IptcDirectory.TagUrgency);
        }

        [CanBeNull]
        public virtual string GetWriterDescription()
        {
            return Directory.GetString(IptcDirectory.TagCaptionWriter);
        }
    }
}
