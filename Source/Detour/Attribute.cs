﻿using System;
using System.Reflection;
using HugsLib.Source.Attrib;

namespace HugsLib.Source.Detour {
    [Flags]
    public enum DetourProperty {
        None = 0,
        Getter = 1,
        Setter = 2,
        Both = Getter | Setter
    }

    [AttributeUsage( AttributeTargets.Method, AllowMultiple = true, Inherited = false )]
    public class DetourMethodAttribute : Attribute, IDetectableAttribute {
        public readonly MethodInfo sourceMethodInfo;
        public readonly string sourceMethodName;
        // store references needed for detours
        public readonly Type sourceType;

        // disable default constructor
        private DetourMethodAttribute() { }

        // get by name
        public DetourMethodAttribute( Type sourceType, string sourceMethodName ) {
            this.sourceType = sourceType;
            this.sourceMethodName = sourceMethodName;
        }

        // get by methodInfo
        public DetourMethodAttribute( MethodInfo methodInfo ) {
            sourceType = methodInfo.DeclaringType;
            sourceMethodInfo = methodInfo;
        }

        // check how this attribute was created
        public bool WasSetByMethodInfo {
            get { return sourceMethodInfo != null; }
        }
    }


    [AttributeUsage( AttributeTargets.Property, AllowMultiple = true, Inherited = false )]
	public class DetourPropertyAttribute : Attribute, IDetectableAttribute {
        public readonly DetourProperty detourProperty;
        // store references needed for detours
        public readonly PropertyInfo sourcePropertyInfo;

        // disable default constructor
        private DetourPropertyAttribute() { }

        // get by name
        public DetourPropertyAttribute( Type sourceType, string sourcePropertyName,
                                        DetourProperty detourProperty = DetourProperty.Both ) {
            sourcePropertyInfo = sourceType.GetProperty( sourcePropertyName, Helpers.AllBindingFlags );
            this.detourProperty = detourProperty;
        }

        // get by propertyInfo
        public DetourPropertyAttribute( PropertyInfo sourcePropertyInfo,
                                        DetourProperty detourProperty = DetourProperty.Both ) {
            this.sourcePropertyInfo = sourcePropertyInfo;
            this.detourProperty = detourProperty;
        }
    }
}
