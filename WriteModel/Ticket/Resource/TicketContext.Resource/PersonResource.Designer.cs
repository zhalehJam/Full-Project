﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TicketContext.Resource {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class PersonResource {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal PersonResource() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("TicketContext.Resource.PersonResource", typeof(PersonResource).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to امکان ویرایش کدپرسنلی وجود ندارد..
        /// </summary>
        public static string CannotChangePersonIDException {
            get {
                return ResourceManager.GetString("CannotChangePersonIDException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to کد پرسنلی نامعتبر است..
        /// </summary>
        public static string InvalidPersonIDException {
            get {
                return ResourceManager.GetString("InvalidPersonIDException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to نقش پرسنل صحیح نمباشد..
        /// </summary>
        public static string InvalidRoleTypeException {
            get {
                return ResourceManager.GetString("InvalidRoleTypeException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to نام پرسنل نمیتواند خالی یا سفید باشد..
        /// </summary>
        public static string NullOrWhitePersonNameException {
            get {
                return ResourceManager.GetString("NullOrWhitePersonNameException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to کدپرسنلی نمیتواند خالی یا صفر باشد..
        /// </summary>
        public static string NullOrZeroPersonIDException {
            get {
                return ResourceManager.GetString("NullOrZeroPersonIDException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to واحد انتخاب شده صحیح نمیباشد..
        /// </summary>
        public static string PartIDIsNotValidException {
            get {
                return ResourceManager.GetString("PartIDIsNotValidException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to کدپرسنلی تکراری است..
        /// </summary>
        public static string PersonIDIsDuplicateException {
            get {
                return ResourceManager.GetString("PersonIDIsDuplicateException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to کدپرسنلی استفاده شده است..
        /// </summary>
        public static string PersonIDIsUsedException {
            get {
                return ResourceManager.GetString("PersonIDIsUsedException", resourceCulture);
            }
        }
    }
}
