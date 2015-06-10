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

using System.Collections.Generic;

namespace MetadataExtractor.Formats.Exif
{
    /// <summary>Base class for several Exif format tag directories.</summary>
    /// <author>Drew Noakes https://drewnoakes.com</author>
    public abstract class ExifDirectoryBase : Directory
    {
        public const int TagInteropIndex = unchecked(0x0001);

        public const int TagInteropVersion = unchecked(0x0002);

        /// <summary>The new subfile type tag.</summary>
        /// <remarks>
        /// The new subfile type tag.
        /// 0 = Full-resolution Image
        /// 1 = Reduced-resolution image
        /// 2 = Single page of multi-page image
        /// 3 = Single page of multi-page reduced-resolution image
        /// 4 = Transparency mask
        /// 5 = Transparency mask of reduced-resolution image
        /// 6 = Transparency mask of multi-page image
        /// 7 = Transparency mask of reduced-resolution multi-page image
        /// </remarks>
        public const int TagNewSubfileType = unchecked(0x00FE);

        /// <summary>The old subfile type tag.</summary>
        /// <remarks>
        /// The old subfile type tag.
        /// 1 = Full-resolution image (Main image)
        /// 2 = Reduced-resolution image (Thumbnail)
        /// 3 = Single page of multi-page image
        /// </remarks>
        public const int TagSubfileType = unchecked(0x00FF);

        public const int TagImageWidth = unchecked(0x0100);

        public const int TagImageHeight = unchecked(0x0101);

        /// <summary>
        /// When image format is no compression, this value shows the number of bits
        /// per component for each pixel.
        /// </summary>
        /// <remarks>
        /// When image format is no compression, this value shows the number of bits
        /// per component for each pixel. Usually this value is '8,8,8'.
        /// </remarks>
        public const int TagBitsPerSample = unchecked(0x0102);

        public const int TagCompression = unchecked(0x0103);

        /// <summary>Shows the color space of the image data components.</summary>
        /// <remarks>
        /// Shows the color space of the image data components.
        /// 0 = WhiteIsZero
        /// 1 = BlackIsZero
        /// 2 = RGB
        /// 3 = RGB Palette
        /// 4 = Transparency Mask
        /// 5 = CMYK
        /// 6 = YCbCr
        /// 8 = CIELab
        /// 9 = ICCLab
        /// 10 = ITULab
        /// 32803 = Color Filter Array
        /// 32844 = Pixar LogL
        /// 32845 = Pixar LogLuv
        /// 34892 = Linear Raw
        /// </remarks>
        public const int TagPhotometricInterpretation = unchecked(0x0106);

        /// <summary>
        /// 1 = No dithering or halftoning
        /// 2 = Ordered dither or halftone
        /// 3 = Randomized dither
        /// </summary>
        public const int TagThresholding = unchecked(0x0107);

        /// <summary>
        /// 1 = Normal
        /// 2 = Reversed
        /// </summary>
        public const int TagFillOrder = unchecked(0x010A);

        public const int TagDocumentName = unchecked(0x010D);

        public const int TagImageDescription = unchecked(0x010E);

        public const int TagMake = unchecked(0x010F);

        public const int TagModel = unchecked(0x0110);

        /// <summary>The position in the file of raster data.</summary>
        public const int TagStripOffsets = unchecked(0x0111);

        public const int TagOrientation = unchecked(0x0112);

        /// <summary>Each pixel is composed of this many samples.</summary>
        public const int TagSamplesPerPixel = unchecked(0x0115);

        /// <summary>The raster is codified by a single block of data holding this many rows.</summary>
        public const int TagRowsPerStrip = unchecked(0x0116);

        /// <summary>The size of the raster data in bytes.</summary>
        public const int TagStripByteCounts = unchecked(0x0117);

        public const int TagMinSampleValue = unchecked(0x0118);

        public const int TagMaxSampleValue = unchecked(0x0119);

        public const int TagXResolution = unchecked(0x011A);

        public const int TagYResolution = unchecked(0x011B);

        /// <summary>
        /// When image format is no compression YCbCr, this value shows byte aligns of
        /// YCbCr data.
        /// </summary>
        /// <remarks>
        /// When image format is no compression YCbCr, this value shows byte aligns of
        /// YCbCr data. If value is '1', Y/Cb/Cr value is chunky format, contiguous for
        /// each subsampling pixel. If value is '2', Y/Cb/Cr value is separated and
        /// stored to Y plane/Cb plane/Cr plane format.
        /// </remarks>
        public const int TagPlanarConfiguration = unchecked(0x011C);

        public const int TagPageName = unchecked(0x011D);

        public const int TagResolutionUnit = unchecked(0x0128);

        public const int TagTransferFunction = unchecked(0x012D);

        public const int TagSoftware = unchecked(0x0131);

        public const int TagDatetime = unchecked(0x0132);

        public const int TagArtist = unchecked(0x013B);

        public const int TagHostComputer = unchecked(0x013C);

        public const int TagPredictor = unchecked(0x013D);

        public const int TagWhitePoint = unchecked(0x013E);

        public const int TagPrimaryChromaticities = unchecked(0x013F);

        public const int TagTileWidth = unchecked(0x0142);

        public const int TagTileLength = unchecked(0x0143);

        public const int TagTileOffsets = unchecked(0x0144);

        public const int TagTileByteCounts = unchecked(0x0145);

        public const int TagSubIfdOffset = unchecked(0x014a);

        public const int TagTransferRange = unchecked(0x0156);

        public const int TagJpegTables = unchecked(0x015B);

        public const int TagJpegProc = unchecked(0x0200);

        public const int TagYcbcrCoefficients = unchecked(0x0211);

        public const int TagYcbcrSubsampling = unchecked(0x0212);

        public const int TagYcbcrPositioning = unchecked(0x0213);

        public const int TagReferenceBlackWhite = unchecked(0x0214);

        public const int TagRelatedImageFileFormat = unchecked(0x1000);

        public const int TagRelatedImageWidth = unchecked(0x1001);

        public const int TagRelatedImageHeight = unchecked(0x1002);

        public const int TagRating = unchecked(0x4746);

        public const int TagCfaRepeatPatternDim = unchecked(0x828D);

        /// <summary>There are two definitions for CFA pattern, I don't know the difference...</summary>
        public const int TagCfaPattern2 = unchecked(0x828E);

        public const int TagBatteryLevel = unchecked(0x828F);

        public const int TagCopyright = unchecked(0x8298);

        /// <summary>Exposure time (reciprocal of shutter speed).</summary>
        /// <remarks>Exposure time (reciprocal of shutter speed). Unit is second.</remarks>
        public const int TagExposureTime = unchecked(0x829A);

        /// <summary>The actual F-number(F-stop) of lens when the image was taken.</summary>
        public const int TagFnumber = unchecked(0x829D);

        public const int TagIptcNaa = unchecked(0x83BB);

        public const int TagInterColorProfile = unchecked(0x8773);

        /// <summary>Exposure program that the camera used when image was taken.</summary>
        /// <remarks>
        /// Exposure program that the camera used when image was taken. '1' means
        /// manual control, '2' program normal, '3' aperture priority, '4' shutter
        /// priority, '5' program creative (slow program), '6' program action
        /// (high-speed program), '7' portrait mode, '8' landscape mode.
        /// </remarks>
        public const int TagExposureProgram = unchecked(0x8822);

        public const int TagSpectralSensitivity = unchecked(0x8824);

        public const int TagIsoEquivalent = unchecked(0x8827);

        /// <summary>Indicates the Opto-Electric Conversion Function (OECF) specified in ISO 14524.</summary>
        /// <remarks>
        /// Indicates the Opto-Electric Conversion Function (OECF) specified in ISO 14524.
        /// <para />
        /// OECF is the relationship between the camera optical input and the image values.
        /// <para />
        /// The values are:
        /// <list type="bullet">
        /// <item>Two shorts, indicating respectively number of columns, and number of rows.</item>
        /// <item>For each column, the column name in a null-terminated ASCII string.</item>
        /// <item>For each cell, an SRATIONAL value.</item>
        /// </list>
        /// </remarks>
        public const int TagOptoElectricConversionFunction = unchecked(0x8828);

        public const int TagInterlace = unchecked(0x8829);

        public const int TagTimeZoneOffsetTiffEp = unchecked(0x882A);

        public const int TagSelfTimerModeTiffEp = unchecked(0x882B);

        /// <summary>Applies to ISO tag.</summary>
        /// <remarks>
        /// Applies to ISO tag.
        /// 0 = Unknown
        /// 1 = Standard Output Sensitivity
        /// 2 = Recommended Exposure Index
        /// 3 = ISO Speed
        /// 4 = Standard Output Sensitivity and Recommended Exposure Index
        /// 5 = Standard Output Sensitivity and ISO Speed
        /// 6 = Recommended Exposure Index and ISO Speed
        /// 7 = Standard Output Sensitivity, Recommended Exposure Index and ISO Speed
        /// </remarks>
        public const int TagSensitivityType = unchecked(0x8830);

        public const int TagStandardOutputSensitivity = unchecked(0x8831);

        public const int TagRecommendedExposureIndex = unchecked(0x8832);

        /// <summary>Non-standard, but in use.</summary>
        public const int TagTimeZoneOffset = unchecked(0x882A);

        public const int TagSelfTimerMode = unchecked(0x882B);

        public const int TagExifVersion = unchecked(0x9000);

        public const int TagDatetimeOriginal = unchecked(0x9003);

        public const int TagDatetimeDigitized = unchecked(0x9004);

        public const int TagComponentsConfiguration = unchecked(0x9101);

        /// <summary>Average (rough estimate) compression level in JPEG bits per pixel.</summary>
        public const int TagCompressedAverageBitsPerPixel = unchecked(0x9102);

        /// <summary>Shutter speed by APEX value.</summary>
        /// <remarks>
        /// Shutter speed by APEX value. To convert this value to ordinary 'Shutter Speed';
        /// calculate this value's power of 2, then reciprocal. For example, if the
        /// ShutterSpeedValue is '4', shutter speed is 1/(24)=1/16 second.
        /// </remarks>
        public const int TagShutterSpeed = unchecked(0x9201);

        /// <summary>The actual aperture value of lens when the image was taken.</summary>
        /// <remarks>
        /// The actual aperture value of lens when the image was taken. Unit is APEX.
        /// To convert this value to ordinary F-number (F-stop), calculate this value's
        /// power of root 2 (=1.4142). For example, if the ApertureValue is '5',
        /// F-number is 1.4142^5 = F5.6.
        /// </remarks>
        public const int TagAperture = unchecked(0x9202);

        public const int TagBrightnessValue = unchecked(0x9203);

        public const int TagExposureBias = unchecked(0x9204);

        /// <summary>Maximum aperture value of lens.</summary>
        /// <remarks>
        /// Maximum aperture value of lens. You can convert to F-number by calculating
        /// power of root 2 (same process of ApertureValue:0x9202).
        /// The actual aperture value of lens when the image was taken. To convert this
        /// value to ordinary f-number(f-stop), calculate the value's power of root 2
        /// (=1.4142). For example, if the ApertureValue is '5', f-number is 1.41425^5 = F5.6.
        /// </remarks>
        public const int TagMaxAperture = unchecked(0x9205);

        /// <summary>Indicates the distance the autofocus camera is focused to.</summary>
        /// <remarks>Indicates the distance the autofocus camera is focused to.  Tends to be less accurate as distance increases.</remarks>
        public const int TagSubjectDistance = unchecked(0x9206);

        /// <summary>Exposure metering method.</summary>
        /// <remarks>
        /// Exposure metering method. '0' means unknown, '1' average, '2' center
        /// weighted average, '3' spot, '4' multi-spot, '5' multi-segment, '6' partial,
        /// '255' other.
        /// </remarks>
        public const int TagMeteringMode = unchecked(0x9207);

        public const int TagLightSource = unchecked(0x9208);

        /// <summary>White balance (aka light source).</summary>
        /// <remarks>
        /// White balance (aka light source). '0' means unknown, '1' daylight,
        /// '2' fluorescent, '3' tungsten, '10' flash, '17' standard light A,
        /// '18' standard light B, '19' standard light C, '20' D55, '21' D65,
        /// '22' D75, '255' other.
        /// </remarks>
        public const int TagWhiteBalance = unchecked(0x9208);

        /// <summary>
        /// 0x0  = 0000000 = No Flash
        /// 0x1  = 0000001 = Fired
        /// 0x5  = 0000101 = Fired, Return not detected
        /// 0x7  = 0000111 = Fired, Return detected
        /// 0x9  = 0001001 = On
        /// 0xd  = 0001101 = On, Return not detected
        /// 0xf  = 0001111 = On, Return detected
        /// 0x10 = 0010000 = Off
        /// 0x18 = 0011000 = Auto, Did not fire
        /// 0x19 = 0011001 = Auto, Fired
        /// 0x1d = 0011101 = Auto, Fired, Return not detected
        /// 0x1f = 0011111 = Auto, Fired, Return detected
        /// 0x20 = 0100000 = No flash function
        /// 0x41 = 1000001 = Fired, Red-eye reduction
        /// 0x45 = 1000101 = Fired, Red-eye reduction, Return not detected
        /// 0x47 = 1000111 = Fired, Red-eye reduction, Return detected
        /// 0x49 = 1001001 = On, Red-eye reduction
        /// 0x4d = 1001101 = On, Red-eye reduction, Return not detected
        /// 0x4f = 1001111 = On, Red-eye reduction, Return detected
        /// 0x59 = 1011001 = Auto, Fired, Red-eye reduction
        /// 0x5d = 1011101 = Auto, Fired, Red-eye reduction, Return not detected
        /// 0x5f = 1011111 = Auto, Fired, Red-eye reduction, Return detected
        /// 6543210 (positions)
        /// This is a bitmask.
        /// </summary>
        /// <remarks>
        /// 0x0  = 0000000 = No Flash
        /// 0x1  = 0000001 = Fired
        /// 0x5  = 0000101 = Fired, Return not detected
        /// 0x7  = 0000111 = Fired, Return detected
        /// 0x9  = 0001001 = On
        /// 0xd  = 0001101 = On, Return not detected
        /// 0xf  = 0001111 = On, Return detected
        /// 0x10 = 0010000 = Off
        /// 0x18 = 0011000 = Auto, Did not fire
        /// 0x19 = 0011001 = Auto, Fired
        /// 0x1d = 0011101 = Auto, Fired, Return not detected
        /// 0x1f = 0011111 = Auto, Fired, Return detected
        /// 0x20 = 0100000 = No flash function
        /// 0x41 = 1000001 = Fired, Red-eye reduction
        /// 0x45 = 1000101 = Fired, Red-eye reduction, Return not detected
        /// 0x47 = 1000111 = Fired, Red-eye reduction, Return detected
        /// 0x49 = 1001001 = On, Red-eye reduction
        /// 0x4d = 1001101 = On, Red-eye reduction, Return not detected
        /// 0x4f = 1001111 = On, Red-eye reduction, Return detected
        /// 0x59 = 1011001 = Auto, Fired, Red-eye reduction
        /// 0x5d = 1011101 = Auto, Fired, Red-eye reduction, Return not detected
        /// 0x5f = 1011111 = Auto, Fired, Red-eye reduction, Return detected
        /// 6543210 (positions)
        /// This is a bitmask.
        /// 0 = flash fired
        /// 1 = return detected
        /// 2 = return able to be detected
        /// 3 = unknown
        /// 4 = auto used
        /// 5 = unknown
        /// 6 = red eye reduction used
        /// </remarks>
        public const int TagFlash = unchecked(0x9209);

        /// <summary>Focal length of lens used to take image.</summary>
        /// <remarks>
        /// Focal length of lens used to take image.  Unit is millimeter.
        /// Nice digital cameras actually save the focal length as a function of how far they are zoomed in.
        /// </remarks>
        public const int TagFocalLength = unchecked(0x920A);

        public const int TagFlashEnergyTiffEp = unchecked(0x920B);

        public const int TagSpatialFreqResponseTiffEp = unchecked(0x920C);

        public const int TagNoise = unchecked(0x920D);

        public const int TagFocalPlaneXResolutionTiffEp = unchecked(0x920E);

        public const int TagFocalPlaneYResolutionTiffEp = unchecked(0x920F);

        public const int TagImageNumber = unchecked(0x9211);

        public const int TagSecurityClassification = unchecked(0x9212);

        public const int TagImageHistory = unchecked(0x9213);

        public const int TagSubjectLocationTiffEp = unchecked(0x9214);

        public const int TagExposureIndexTiffEp = unchecked(0x9215);

        public const int TagStandardIdTiffEp = unchecked(0x9216);

        /// <summary>This tag holds the Exif Makernote.</summary>
        /// <remarks>
        /// This tag holds the Exif Makernote. Makernotes are free to be in any format, though they are often IFDs.
        /// To determine the format, we consider the starting bytes of the makernote itself and sometimes the
        /// camera model and make.
        /// <para />
        /// The component count for this tag includes all of the bytes needed for the makernote.
        /// </remarks>
        public const int TagMakernote = unchecked(0x927C);

        public const int TagUserComment = unchecked(0x9286);

        public const int TagSubsecondTime = unchecked(0x9290);

        public const int TagSubsecondTimeOriginal = unchecked(0x9291);

        public const int TagSubsecondTimeDigitized = unchecked(0x9292);

        /// <summary>The image title, as used by Windows XP.</summary>
        public const int TagWinTitle = unchecked(0x9C9B);

        /// <summary>The image comment, as used by Windows XP.</summary>
        public const int TagWinComment = unchecked(0x9C9C);

        /// <summary>The image author, as used by Windows XP (called Artist in the Windows shell).</summary>
        public const int TagWinAuthor = unchecked(0x9C9D);

        /// <summary>The image keywords, as used by Windows XP.</summary>
        public const int TagWinKeywords = unchecked(0x9C9E);

        /// <summary>The image subject, as used by Windows XP.</summary>
        public const int TagWinSubject = unchecked(0x9C9F);

        public const int TagFlashpixVersion = unchecked(0xA000);

        /// <summary>Defines Color Space.</summary>
        /// <remarks>
        /// Defines Color Space. DCF image must use sRGB color space so value is
        /// always '1'. If the picture uses the other color space, value is
        /// '65535':Uncalibrated.
        /// </remarks>
        public const int TagColorSpace = unchecked(0xA001);

        public const int TagExifImageWidth = unchecked(0xA002);

        public const int TagExifImageHeight = unchecked(0xA003);

        public const int TagRelatedSoundFile = unchecked(0xA004);

        public const int TagFlashEnergy = unchecked(0xA20B);

        public const int TagSpatialFreqResponse = unchecked(0xA20C);

        public const int TagFocalPlaneXResolution = unchecked(0xA20E);

        public const int TagFocalPlaneYResolution = unchecked(0xA20F);

        /// <summary>Unit of FocalPlaneXResolution/FocalPlaneYResolution.</summary>
        /// <remarks>
        /// Unit of FocalPlaneXResolution/FocalPlaneYResolution. '1' means no-unit,
        /// '2' inch, '3' centimeter.
        /// Note: Some of Fujifilm's digicam(e.g.FX2700,FX2900,Finepix4700Z/40i etc)
        /// uses value '3' so it must be 'centimeter', but it seems that they use a
        /// '8.3mm?'(1/3in.?) to their ResolutionUnit. Fuji's BUG? Finepix4900Z has
        /// been changed to use value '2' but it doesn't match to actual value also.
        /// </remarks>
        public const int TagFocalPlaneResolutionUnit = unchecked(0xA210);

        public const int TagSubjectLocation = unchecked(0xA214);

        public const int TagExposureIndex = unchecked(0xA215);

        public const int TagSensingMethod = unchecked(0xA217);

        public const int TagFileSource = unchecked(0xA300);

        public const int TagSceneType = unchecked(0xA301);

        public const int TagCfaPattern = unchecked(0xA302);

        /// <summary>
        /// This tag indicates the use of special processing on image data, such as rendering
        /// geared to output.
        /// </summary>
        /// <remarks>
        /// This tag indicates the use of special processing on image data, such as rendering
        /// geared to output. When special processing is performed, the reader is expected to
        /// disable or minimize any further processing.
        /// Tag = 41985 (A401.H)
        /// Type = SHORT
        /// Count = 1
        /// Default = 0
        /// 0 = Normal process
        /// 1 = Custom process
        /// Other = reserved
        /// </remarks>
        public const int TagCustomRendered = unchecked(0xA401);

        /// <summary>This tag indicates the exposure mode set when the image was shot.</summary>
        /// <remarks>
        /// This tag indicates the exposure mode set when the image was shot. In auto-bracketing
        /// mode, the camera shoots a series of frames of the same scene at different exposure settings.
        /// Tag = 41986 (A402.H)
        /// Type = SHORT
        /// Count = 1
        /// Default = none
        /// 0 = Auto exposure
        /// 1 = Manual exposure
        /// 2 = Auto bracket
        /// Other = reserved
        /// </remarks>
        public const int TagExposureMode = unchecked(0xA402);

        /// <summary>This tag indicates the white balance mode set when the image was shot.</summary>
        /// <remarks>
        /// This tag indicates the white balance mode set when the image was shot.
        /// Tag = 41987 (A403.H)
        /// Type = SHORT
        /// Count = 1
        /// Default = none
        /// 0 = Auto white balance
        /// 1 = Manual white balance
        /// Other = reserved
        /// </remarks>
        public const int TagWhiteBalanceMode = unchecked(0xA403);

        /// <summary>This tag indicates the digital zoom ratio when the image was shot.</summary>
        /// <remarks>
        /// This tag indicates the digital zoom ratio when the image was shot. If the
        /// numerator of the recorded value is 0, this indicates that digital zoom was
        /// not used.
        /// Tag = 41988 (A404.H)
        /// Type = RATIONAL
        /// Count = 1
        /// Default = none
        /// </remarks>
        public const int TagDigitalZoomRatio = unchecked(0xA404);

        /// <summary>
        /// This tag indicates the equivalent focal length assuming a 35mm film camera,
        /// in mm.
        /// </summary>
        /// <remarks>
        /// This tag indicates the equivalent focal length assuming a 35mm film camera,
        /// in mm. A value of 0 means the focal length is unknown. Note that this tag
        /// differs from the FocalLength tag.
        /// Tag = 41989 (A405.H)
        /// Type = SHORT
        /// Count = 1
        /// Default = none
        /// </remarks>
        public const int Tag35MmFilmEquivFocalLength = unchecked(0xA405);

        /// <summary>This tag indicates the type of scene that was shot.</summary>
        /// <remarks>
        /// This tag indicates the type of scene that was shot. It can also be used to
        /// record the mode in which the image was shot. Note that this differs from
        /// the scene type (SceneType) tag.
        /// Tag = 41990 (A406.H)
        /// Type = SHORT
        /// Count = 1
        /// Default = 0
        /// 0 = Standard
        /// 1 = Landscape
        /// 2 = Portrait
        /// 3 = Night scene
        /// Other = reserved
        /// </remarks>
        public const int TagSceneCaptureType = unchecked(0xA406);

        /// <summary>This tag indicates the degree of overall image gain adjustment.</summary>
        /// <remarks>
        /// This tag indicates the degree of overall image gain adjustment.
        /// Tag = 41991 (A407.H)
        /// Type = SHORT
        /// Count = 1
        /// Default = none
        /// 0 = None
        /// 1 = Low gain up
        /// 2 = High gain up
        /// 3 = Low gain down
        /// 4 = High gain down
        /// Other = reserved
        /// </remarks>
        public const int TagGainControl = unchecked(0xA407);

        /// <summary>
        /// This tag indicates the direction of contrast processing applied by the camera
        /// when the image was shot.
        /// </summary>
        /// <remarks>
        /// This tag indicates the direction of contrast processing applied by the camera
        /// when the image was shot.
        /// Tag = 41992 (A408.H)
        /// Type = SHORT
        /// Count = 1
        /// Default = 0
        /// 0 = Normal
        /// 1 = Soft
        /// 2 = Hard
        /// Other = reserved
        /// </remarks>
        public const int TagContrast = unchecked(0xA408);

        /// <summary>
        /// This tag indicates the direction of saturation processing applied by the camera
        /// when the image was shot.
        /// </summary>
        /// <remarks>
        /// This tag indicates the direction of saturation processing applied by the camera
        /// when the image was shot.
        /// Tag = 41993 (A409.H)
        /// Type = SHORT
        /// Count = 1
        /// Default = 0
        /// 0 = Normal
        /// 1 = Low saturation
        /// 2 = High saturation
        /// Other = reserved
        /// </remarks>
        public const int TagSaturation = unchecked(0xA409);

        /// <summary>
        /// This tag indicates the direction of sharpness processing applied by the camera
        /// when the image was shot.
        /// </summary>
        /// <remarks>
        /// This tag indicates the direction of sharpness processing applied by the camera
        /// when the image was shot.
        /// Tag = 41994 (A40A.H)
        /// Type = SHORT
        /// Count = 1
        /// Default = 0
        /// 0 = Normal
        /// 1 = Soft
        /// 2 = Hard
        /// Other = reserved
        /// </remarks>
        public const int TagSharpness = unchecked(0xA40A);

        /// <summary>
        /// This tag indicates information on the picture-taking conditions of a particular
        /// camera model.
        /// </summary>
        /// <remarks>
        /// This tag indicates information on the picture-taking conditions of a particular
        /// camera model. The tag is used only to indicate the picture-taking conditions in
        /// the reader.
        /// Tag = 41995 (A40B.H)
        /// Type = UNDEFINED
        /// Count = Any
        /// Default = none
        /// The information is recorded in the format shown below. The data is recorded
        /// in Unicode using SHORT type for the number of display rows and columns and
        /// UNDEFINED type for the camera settings. The Unicode (UCS-2) string including
        /// Signature is NULL terminated. The specifics of the Unicode string are as given
        /// in ISO/IEC 10464-1.
        /// Length  Type        Meaning
        /// ------+-----------+------------------
        /// 2       SHORT       Display columns
        /// 2       SHORT       Display rows
        /// Any     UNDEFINED   Camera setting-1
        /// Any     UNDEFINED   Camera setting-2
        /// :       :           :
        /// Any     UNDEFINED   Camera setting-n
        /// </remarks>
        public const int TagDeviceSettingDescription = unchecked(0xA40B);

        /// <summary>This tag indicates the distance to the subject.</summary>
        /// <remarks>
        /// This tag indicates the distance to the subject.
        /// Tag = 41996 (A40C.H)
        /// Type = SHORT
        /// Count = 1
        /// Default = none
        /// 0 = unknown
        /// 1 = Macro
        /// 2 = Close view
        /// 3 = Distant view
        /// Other = reserved
        /// </remarks>
        public const int TagSubjectDistanceRange = unchecked(0xA40C);

        /// <summary>This tag indicates an identifier assigned uniquely to each image.</summary>
        /// <remarks>
        /// This tag indicates an identifier assigned uniquely to each image. It is
        /// recorded as an ASCII string equivalent to hexadecimal notation and 128-bit
        /// fixed length.
        /// Tag = 42016 (A420.H)
        /// Type = ASCII
        /// Count = 33
        /// Default = none
        /// </remarks>
        public const int TagImageUniqueId = unchecked(0xA420);

        /// <summary>String.</summary>
        public const int TagCameraOwnerName = unchecked(0xA430);

        /// <summary>String.</summary>
        public const int TagBodySerialNumber = unchecked(0xA431);

        /// <summary>An array of four Rational64u numbers giving focal and aperture ranges.</summary>
        public const int TagLensSpecification = unchecked(0xA432);

        /// <summary>String.</summary>
        public const int TagLensMake = unchecked(0xA433);

        /// <summary>String.</summary>
        public const int TagLensModel = unchecked(0xA434);

        /// <summary>String.</summary>
        public const int TagLensSerialNumber = unchecked(0xA435);

        /// <summary>Rational64u.</summary>
        public const int TagGamma = unchecked(0xA500);

        public const int TagPrintIm = unchecked(0xC4A5);

        public const int TagPanasonicTitle = unchecked(0xC6D2);

        public const int TagPanasonicTitle2 = unchecked(0xC6D3);

        public const int TagPadding = unchecked(0xEA1C);

        public const int TagLens = unchecked(0xFDEA);

        // TODO duplicate tag
        // TODO duplicate tag
        protected static void AddExifTagNames(Dictionary<int?, string> map)
        {
            map[TagInteropIndex] = "Interoperability Index";
            map[TagInteropVersion] = "Interoperability Version";
            map[TagNewSubfileType] = "New Subfile Type";
            map[TagSubfileType] = "Subfile Type";
            map[TagImageWidth] = "Image Width";
            map[TagImageHeight] = "Image Height";
            map[TagBitsPerSample] = "Bits Per Sample";
            map[TagCompression] = "Compression";
            map[TagPhotometricInterpretation] = "Photometric Interpretation";
            map[TagThresholding] = "Thresholding";
            map[TagFillOrder] = "Fill Order";
            map[TagDocumentName] = "Document Name";
            map[TagImageDescription] = "Image Description";
            map[TagMake] = "Make";
            map[TagModel] = "Model";
            map[TagStripOffsets] = "Strip Offsets";
            map[TagOrientation] = "Orientation";
            map[TagSamplesPerPixel] = "Samples Per Pixel";
            map[TagRowsPerStrip] = "Rows Per Strip";
            map[TagStripByteCounts] = "Strip Byte Counts";
            map[TagMinSampleValue] = "Minimum sample value";
            map[TagMaxSampleValue] = "Maximum sample value";
            map[TagXResolution] = "X Resolution";
            map[TagYResolution] = "Y Resolution";
            map[TagPlanarConfiguration] = "Planar Configuration";
            map[TagPageName] = "Page Name";
            map[TagResolutionUnit] = "Resolution Unit";
            map[TagTransferFunction] = "Transfer Function";
            map[TagSoftware] = "Software";
            map[TagDatetime] = "Date/Time";
            map[TagArtist] = "Artist";
            map[TagPredictor] = "Predictor";
            map[TagHostComputer] = "Host Computer";
            map[TagWhitePoint] = "White Point";
            map[TagPrimaryChromaticities] = "Primary Chromaticities";
            map[TagTileWidth] = "Tile Width";
            map[TagTileLength] = "Tile Length";
            map[TagTileOffsets] = "Tile Offsets";
            map[TagTileByteCounts] = "Tile Byte Counts";
            map[TagSubIfdOffset] = "Sub IFD Pointer(s)";
            map[TagTransferRange] = "Transfer Range";
            map[TagJpegTables] = "JPEG Tables";
            map[TagJpegProc] = "JPEG Proc";
            map[TagYcbcrCoefficients] = "YCbCr Coefficients";
            map[TagYcbcrSubsampling] = "YCbCr Sub-Sampling";
            map[TagYcbcrPositioning] = "YCbCr Positioning";
            map[TagReferenceBlackWhite] = "Reference Black/White";
            map[TagRelatedImageFileFormat] = "Related Image File Format";
            map[TagRelatedImageWidth] = "Related Image Width";
            map[TagRelatedImageHeight] = "Related Image Height";
            map[TagRating] = "Rating";
            map[TagCfaRepeatPatternDim] = "CFA Repeat Pattern Dim";
            map[TagCfaPattern2] = "CFA Pattern";
            map[TagBatteryLevel] = "Battery Level";
            map[TagCopyright] = "Copyright";
            map[TagExposureTime] = "Exposure Time";
            map[TagFnumber] = "F-Number";
            map[TagIptcNaa] = "IPTC/NAA";
            map[TagInterColorProfile] = "Inter Color Profile";
            map[TagExposureProgram] = "Exposure Program";
            map[TagSpectralSensitivity] = "Spectral Sensitivity";
            map[TagIsoEquivalent] = "ISO Speed Ratings";
            map[TagOptoElectricConversionFunction] = "Opto-electric Conversion Function (OECF)";
            map[TagInterlace] = "Interlace";
            map[TagTimeZoneOffsetTiffEp] = "Time Zone Offset";
            map[TagSelfTimerModeTiffEp] = "Self Timer Mode";
            map[TagSensitivityType] = "Sensitivity Type";
            map[TagStandardOutputSensitivity] = "Standard Output Sensitivity";
            map[TagRecommendedExposureIndex] = "Recommended Exposure Index";
            map[TagTimeZoneOffset] = "Time Zone Offset";
            map[TagSelfTimerMode] = "Self Timer Mode";
            map[TagExifVersion] = "Exif Version";
            map[TagDatetimeOriginal] = "Date/Time Original";
            map[TagDatetimeDigitized] = "Date/Time Digitized";
            map[TagComponentsConfiguration] = "Components Configuration";
            map[TagCompressedAverageBitsPerPixel] = "Compressed Bits Per Pixel";
            map[TagShutterSpeed] = "Shutter Speed Value";
            map[TagAperture] = "Aperture Value";
            map[TagBrightnessValue] = "Brightness Value";
            map[TagExposureBias] = "Exposure Bias Value";
            map[TagMaxAperture] = "Max Aperture Value";
            map[TagSubjectDistance] = "Subject Distance";
            map[TagMeteringMode] = "Metering Mode";
            map[TagLightSource] = "Light Source";
            map[TagWhiteBalance] = "White Balance";
            map[TagFlash] = "Flash";
            map[TagFocalLength] = "Focal Length";
            map[TagFlashEnergyTiffEp] = "Flash Energy";
            map[TagSpatialFreqResponseTiffEp] = "Spatial Frequency Response";
            map[TagNoise] = "Noise";
            map[TagFocalPlaneXResolutionTiffEp] = "Focal Plane X Resolution";
            map[TagFocalPlaneYResolutionTiffEp] = "Focal Plane Y Resolution";
            map[TagImageNumber] = "Image Number";
            map[TagSecurityClassification] = "Security Classification";
            map[TagImageHistory] = "Image History";
            map[TagSubjectLocationTiffEp] = "Subject Location";
            map[TagExposureIndexTiffEp] = "Exposure Index";
            map[TagStandardIdTiffEp] = "TIFF/EP Standard ID";
            map[TagMakernote] = "Makernote";
            map[TagUserComment] = "User Comment";
            map[TagSubsecondTime] = "Sub-Sec Time";
            map[TagSubsecondTimeOriginal] = "Sub-Sec Time Original";
            map[TagSubsecondTimeDigitized] = "Sub-Sec Time Digitized";
            map[TagWinTitle] = "Windows XP Title";
            map[TagWinComment] = "Windows XP Comment";
            map[TagWinAuthor] = "Windows XP Author";
            map[TagWinKeywords] = "Windows XP Keywords";
            map[TagWinSubject] = "Windows XP Subject";
            map[TagFlashpixVersion] = "FlashPix Version";
            map[TagColorSpace] = "Color Space";
            map[TagExifImageWidth] = "Exif Image Width";
            map[TagExifImageHeight] = "Exif Image Height";
            map[TagRelatedSoundFile] = "Related Sound File";
            map[TagFlashEnergy] = "Flash Energy";
            map[TagSpatialFreqResponse] = "Spatial Frequency Response";
            map[TagFocalPlaneXResolution] = "Focal Plane X Resolution";
            map[TagFocalPlaneYResolution] = "Focal Plane Y Resolution";
            map[TagFocalPlaneResolutionUnit] = "Focal Plane Resolution Unit";
            map[TagSubjectLocation] = "Subject Location";
            map[TagExposureIndex] = "Exposure Index";
            map[TagSensingMethod] = "Sensing Method";
            map[TagFileSource] = "File Source";
            map[TagSceneType] = "Scene Type";
            map[TagCfaPattern] = "CFA Pattern";
            map[TagCustomRendered] = "Custom Rendered";
            map[TagExposureMode] = "Exposure Mode";
            map[TagWhiteBalanceMode] = "White Balance Mode";
            map[TagDigitalZoomRatio] = "Digital Zoom Ratio";
            map[Tag35MmFilmEquivFocalLength] = "Focal Length 35";
            map[TagSceneCaptureType] = "Scene Capture Type";
            map[TagGainControl] = "Gain Control";
            map[TagContrast] = "Contrast";
            map[TagSaturation] = "Saturation";
            map[TagSharpness] = "Sharpness";
            map[TagDeviceSettingDescription] = "Device Setting Description";
            map[TagSubjectDistanceRange] = "Subject Distance Range";
            map[TagImageUniqueId] = "Unique Image ID";
            map[TagCameraOwnerName] = "Camera Owner Name";
            map[TagBodySerialNumber] = "Body Serial Number";
            map[TagLensSpecification] = "Lens Specification";
            map[TagLensMake] = "Lens Make";
            map[TagLensModel] = "Lens Model";
            map[TagLensSerialNumber] = "Lens Serial Number";
            map[TagGamma] = "Gamma";
            map[TagPrintIm] = "Print IM";
            map[TagPanasonicTitle] = "Panasonic Title";
            map[TagPanasonicTitle2] = "Panasonic Title (2)";
            map[TagPadding] = "Padding";
            map[TagLens] = "Lens";
        }
    }
}