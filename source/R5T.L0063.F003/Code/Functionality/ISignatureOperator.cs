using System;
using System.Collections.Generic;
using System.Linq;

using R5T.L0053.Extensions;
using R5T.L0062.T000;
using R5T.L0062.T000.Extensions;
using R5T.T0132;

using R5T.L0063.T001;


namespace R5T.L0063.F003
{
    /// <summary>
    /// Operations to get signature strings from structured signature types.
    /// </summary>
    [FunctionalityMarker]
    public partial interface ISignatureOperator : IFunctionalityMarker
    {
        public IIdentityString Get_IdentityString(Signature signature)
        {
            var identityStringValue = signature switch
            {
                EventSignature eventSignature => this.Get_IdentityString_ForEvent(eventSignature),
                FieldSignature fieldSignature => this.Get_IdentityString_ForField(fieldSignature),
                PropertySignature propertySignature => this.Get_IdentityString_ForProperty(propertySignature),
                MethodSignature methodSignature => this.Get_IdentityString_ForMethod(methodSignature),
                TypeSignature typeSignature => this.Get_IdentityString_ForType(typeSignature),
                _ => throw Instances.ExceptionOperator.Get_UnrecognizedSignatureType(signature)
            };

            var output = identityStringValue.ToIdentityString();
            return output;
        }

        public string Get_IdentityString_ForEvent(EventSignature eventSignature)
        {
            var declaringTypeIdentityStringValue = this.Get_IdentityStringValue_ForType(eventSignature.DeclaringType);

            var eventIdentityString = Instances.SignatureStringOperator.Combine(
                declaringTypeIdentityStringValue,
                eventSignature.EventName);

            var output = Instances.IdentityStringOperator.Get_EventIdentityString(eventIdentityString);
            return output;
        }

        public string Get_IdentityString_ForField(FieldSignature fieldSignature)
        {
            var declaringTypeIdentityStringValue = this.Get_IdentityStringValue_ForType(fieldSignature.DeclaringType);

            var fieldIdentityString = Instances.SignatureStringOperator.Combine(
                declaringTypeIdentityStringValue,
                fieldSignature.FieldName);

            var output = Instances.IdentityStringOperator.Get_FieldIdentityString(fieldIdentityString);
            return output;
        }

        public string Get_IdentityString_ForMethod(MethodSignature methodSignature)
        {
            var declaringTypeIdentityStringValue = this.Get_IdentityStringValue_ForType(methodSignature.DeclaringType);

            var methodNameIdentityString = Instances.SignatureStringOperator.Combine(
                declaringTypeIdentityStringValue,
                methodSignature.MethodName);

            var genericTypeInputsList = this.Get_GenericMethodTypeParameterCountToken(methodSignature.GenericTypeInputs);

            methodNameIdentityString = Instances.SignatureStringOperator.Append_TypeParameterList(
                methodNameIdentityString,
                genericTypeInputsList);

            var parametersList = this.Get_ParametersList(
                methodSignature.DeclaringType,
                methodSignature.GenericTypeInputs,
                methodSignature.Parameters);

            methodNameIdentityString = Instances.SignatureStringOperator.Append_ParameterList(
                methodNameIdentityString,
                parametersList);

            var output = Instances.IdentityStringOperator.Get_MethodIdentityString(methodNameIdentityString);
            return output;
        }

        public string Get_IdentityString_ForProperty(PropertySignature propertySignature)
        {
            var declaringTypeIdentityStringValue = this.Get_IdentityStringValue_ForType(propertySignature.DeclaringType);

            var propertyNameIdentityString = Instances.SignatureStringOperator.Combine(
                declaringTypeIdentityStringValue,
                propertySignature.PropertyName);

            var parametersList = this.Get_ParametersList(
                propertySignature.DeclaringType,
                Instances.ArrayOperator.Empty<TypeSignature>(),
                propertySignature.Parameters);

            propertyNameIdentityString = Instances.SignatureStringOperator.Append_ParameterList(
                propertyNameIdentityString,
                parametersList);

            var output = Instances.IdentityStringOperator.Get_PropertyIdentityString(propertyNameIdentityString);
            return output;
        }

        ///// <summary>
        ///// In identity strings, 
        ///// </summary>
        //public string Get_IdentityStringValue_ForType_ForParameters(TypeSignature typeSignature)
        //{
            
        //}

        public string Get_IdentityStringValue_ForType(TypeSignature typeSignature)
        {
            string typeIdentityStringValue;

            if (typeSignature.Is_Nested)
            {
                var parentTypeSignature = this.Get_IdentityStringValue_ForType(typeSignature.NestedTypeParent);

                typeIdentityStringValue = Instances.SignatureStringOperator.Append_NestedTypeTypeName(
                    parentTypeSignature,
                    typeSignature.TypeName);
            }
            else
            {
                typeIdentityStringValue = Instances.SignatureStringOperator.Combine(
                    typeSignature.NamespaceName,
                    typeSignature.TypeName);
            }

            // No need to check if null or empty; if so, an empty string will be returned.
            var genericTypeInputsList = this.Get_GenericTypeParameterCountToken(typeSignature.GenericTypeInputs);

            typeIdentityStringValue = Instances.SignatureStringOperator.Append_TypeParameterList(
                typeIdentityStringValue,
                genericTypeInputsList);

            return typeIdentityStringValue;
        }

        public string Get_IdentityString_ForType(TypeSignature typeSignature)
        {
            string typeIdentityStringValue = this.Get_IdentityStringValue_ForType(typeSignature);

            var output = Instances.IdentityStringOperator.Get_TypeIdentityString(typeIdentityStringValue);
            return output;
        }

        /// <summary>
        /// Note: can handle the null and empty case (returns an empty string).
        /// </summary>
        public string Get_GenericTypeParameterCountToken(TypeSignature[] genericTypeInputs = default)
        {
            var isNull = genericTypeInputs == default;
            if(isNull)
            {
                return String.Empty;
            }

            var hasGenericTypeInputs = genericTypeInputs.Any();
            if (!hasGenericTypeInputs)
            {
                return String.Empty;
            }

            var genericTypeParameterCount = genericTypeInputs.Length;

            var output = Instances.IdentityStringOperator.Get_GenericTypeParameterCountToken(genericTypeParameterCount);
            return output;
        }

        /// <summary>
        /// Note: can handle the null and empty case (returns an empty string).
        /// </summary>
        public string Get_GenericMethodTypeParameterCountToken(TypeSignature[] genericTypeInputs = default)
        {
            var isNull = genericTypeInputs == default;
            if (isNull)
            {
                return String.Empty;
            }

            var hasGenericTypeInputs = genericTypeInputs.Any();
            if (!hasGenericTypeInputs)
            {
                return String.Empty;
            }

            var genericTypeParameterCount = genericTypeInputs.Length;

            var output = Instances.IdentityStringOperator.Get_GenericMethodParameterCountToken(genericTypeParameterCount);
            return output;
        }

        /// <summary>
        /// Note: can handle the null and empty case (returns an empty string).
        /// </summary>
        public string Get_ParametersList(
            TypeSignature declaringTypeSignature,
            TypeSignature[] methodGenericTypeInputs,
            MethodParameter[] parameters = default)
        {
            var isNull = parameters == default;
            if (isNull)
            {
                return String.Empty;
            }

            var hasParameter = parameters.Any();
            if (!hasParameter)
            {
                return String.Empty;
            }

            static void AddNestedTypeGenericTypeInputs(
                TypeSignature typeSignature,
                List<TypeSignature> genericTypeInputs)
            {
                if(typeSignature.Is_Nested)
                {
                    AddNestedTypeGenericTypeInputs(
                        typeSignature.NestedTypeParent,
                        genericTypeInputs);
                }

                var hasTypeGenericTypeInputs = typeSignature.GenericTypeInputs is object;
                if(hasTypeGenericTypeInputs)
                {
                    genericTypeInputs.AddRange(typeSignature.GenericTypeInputs);
                }
            }

            var typeGenericTypeInputs = new List<TypeSignature>();

            AddNestedTypeGenericTypeInputs(
                declaringTypeSignature,
                typeGenericTypeInputs);

            var typeIndex = 0;
            var genericTypeParameterPositionsByName = typeGenericTypeInputs
                .ToDictionary(
                    x => x.TypeName,
                    x => typeIndex++);

            var methodHasGenericTypeInputs = methodGenericTypeInputs is object;

            var methodIndex = 0;
            var methodGenericTypeParameterPositionsByName = methodHasGenericTypeInputs
                ? methodGenericTypeInputs
                    .ToDictionary(
                        x => x.TypeName,
                        x => methodIndex++)
                : new Dictionary<string, int>()
                ;

            var output = parameters
                .Select(parameter => this.Get_ParameterToken(
                    parameter,
                    genericTypeParameterPositionsByName,
                    methodGenericTypeParameterPositionsByName))
                .Join(Instances.TokenSeparators_IdentityString.ArgumentListSeparator)
                .Wrap(
                    Instances.TokenSeparators_IdentityString.ParameterListOpenTokenSeparator,
                    Instances.TokenSeparators_IdentityString.ParameterListCloseTokenSeparator);

            return output;
        }

        public string Get_ParameterToken(
            MethodParameter parameter,
            IDictionary<string, int> genericTypeParameterPositionsByName,
            IDictionary<string, int> methodGenericTypeParameterPositionsByName)
        {
            if(parameter.ParameterType.Is_GenericTypeParameter)
            {
                var index = genericTypeParameterPositionsByName[parameter.ParameterType.TypeName];

                var output = Instances.TypeNameOperator.Get_PositionalTypeName_ForGenericTypeParameter(index);
                return output;
            }
            else if(parameter.ParameterType.Is_GenericMethodParameter)
            {
                var index = methodGenericTypeParameterPositionsByName[parameter.ParameterType.TypeName];

                var output = Instances.TypeNameOperator.Get_PositionalTypeName_ForGenericMethodParameter(index);
                return output;
            }
            else
            { 
                var parameterTypeIdentityStringValue = this.Get_IdentityStringValue_ForType(parameter.ParameterType);

                // For identity names, the parameter name is not included.
                var output = parameterTypeIdentityStringValue;
                return output;
            }
        }
    }
}
