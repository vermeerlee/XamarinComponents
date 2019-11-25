﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using Xamarin.iOS.Binding.Transformer.Attributes;
using Xamarin.iOS.Binding.Transformer.Models.Collections;

namespace Xamarin.iOS.Binding.Transformer
{
    [XmlRoot(ElementName = "property")]
    public class ApiProperty : ApiObject
    {
        [ChangeIgnore]
        protected internal override string NodeName => $"property[@name='{NativeName}']";

        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }

        [XmlAttribute(AttributeName = "nullallowed")]
        public bool IsNullAllowed { get; set; }

        [XmlAttribute(AttributeName = "abstract")]
        public bool IsAbstract { get; set; }

        [XmlAttribute(AttributeName = "export")]
        public string ExportName { get; set; }

        [XmlAttribute(AttributeName = "get")]
        public bool CanGet { get; set; }

        [XmlAttribute(AttributeName = "get_bind")]
        public string GetBindName { get; set; }

        [XmlAttribute(AttributeName = "set")]
        public bool CanSet { get; set; }

        [XmlAttribute(AttributeName = "set_bind")]
        public string SetBindName { get; set; }

        internal static ApiProperty Clone()
        {
            throw new NotImplementedException();
        }

        [XmlAttribute(AttributeName = "semanticstrength")]
        public string SemanticStrength { get; set; }

        [XmlAttribute(AttributeName = "wrap")]
        public string WrapName { get; set; }

        [XmlAttribute(AttributeName = "ios_version")]
        public string IosVersion { get; set; }

        [XmlAttribute(AttributeName = "tv_version")]
        public string TVVersion { get; set; }

        [XmlAttribute(AttributeName = "introduced_flag")]
        public bool Introduced { get; set; }

        [XmlAttribute(AttributeName = "static")]
        public bool IsStatic { get; set; }

        [XmlAttribute(AttributeName = "internal")]
        public bool IsInternal { get; set; }

        [XmlAttribute(AttributeName = "new")]
        public bool IsNew { get; set; }

        [XmlAttribute(AttributeName = "notification")]
        public bool ShouldNotify { get; set; }

        [ChangeIgnore]
        [XmlElement(ElementName = "verify")]
        public ApiVerify Verify { get; set; }

        [XmlAttribute(AttributeName = "field_params")]
        public string FieldParams { get; set; }

        [XmlAttribute(AttributeName = "obsolete")]
        public string Obsolete { get; set; }

        [ChangeIgnore]
        [XmlIgnore]
        public string NativeName
        {
            get
            {
                //if (!string.IsNullOrWhiteSpace(ExportName))
                //    return ExportName;

                return Name;
            }
        }

        /// <summary>
        /// The VerifyType value - redirects to Verify.VerifyType
        /// </summary>
        [XmlIgnore]
        public string VerifyType
        {
            get { return Verify?.VerifyType; }
            set
            {
                if (Verify == null)
                    Verify = new ApiVerify();

                Verify.VerifyType = value;
            }
        }

        public ApiProperty()
        {

        }

        internal protected override void SetParent(ApiObject parent)
        {
            base.SetParentInternal(parent);
        }

        internal protected override void UpdatePathList(ref Dictionary<string, ApiObject> dict)
        {
            dict.Add(Path, this);
        }

        internal override void Add(ApiObject item)
        {

        }

        internal override void Remove(ApiObject item)
        {

        }

        public override void RemovePrefix(string prefix)
        {
            if (Name.StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
            {
                Name = Name.Replace(prefix, "", StringComparison.OrdinalIgnoreCase);

                if (Name.StartsWith("_"))
                    Name = Name.Substring(1);

                if (char.IsLower(Name[0]))
                    Name = Name.First().ToString().ToUpper() + Name.Substring(1);
            }

           if (Type.Contains(prefix))
            {
                Type = Type.Replace(prefix, "");
            }
        }
    }
}
