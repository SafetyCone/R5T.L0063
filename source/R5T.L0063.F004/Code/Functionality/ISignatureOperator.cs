using System;
using System.Linq;

using R5T.L0053.Extensions;
using R5T.T0132;

using R5T.L0063.T000;
using R5T.L0063.T000.Extensions;
using R5T.L0063.T001;


namespace R5T.L0063.F004
{
    [FunctionalityMarker]
    public partial interface ISignatureOperator : IFunctionalityMarker
    {
        public ISignatureString Get_SignatureString(Signature signature)
        {
            var signatureStringValueWithoutObsolete = signature switch
            {
                EventSignature eventSignature => this.Get_SignatureString_ForEvent(eventSignature),
                FieldSignature fieldSignature => this.Get_SignatureString_ForField(fieldSignature),
                PropertySignature propertySignature => this.Get_SignatureString_ForProperty(propertySignature),
                MethodSignature methodSignature => this.Get_SignatureString_ForMethod(methodSignature),
                TypeSignature typeSignature => this.Get_SignatureString_ForType(typeSignature),
                _ => throw Instances.ExceptionOperator.Get_UnrecognizedSignatureType(signature)
            };

            var signatureStringValue = signature.IsObsolete
                ? Instances.SignatureStringOperator.Append_ObsoleteToken(signatureStringValueWithoutObsolete)
                : signatureStringValueWithoutObsolete
                ;

            var output = signatureStringValue.ToSignatureString();
            return output;
        }

        public string Get_SignatureString_ForEvent(EventSignature eventSignature)
        {
            var declaringTypeSignatureStringValue = this.Get_SignatureStringValue_ForType(eventSignature.DeclaringType);
            var eventHandlerTypeSignatureStringValue = this.Get_SignatureStringValue_ForType(eventSignature.EventHandlerType);

            var eventSignatureString = Instances.SignatureStringOperator.Combine(
                declaringTypeSignatureStringValue,
                eventSignature.EventName);

            eventSignatureString = Instances.SignatureStringOperator.Append_OutputType(
                eventSignatureString,
                eventHandlerTypeSignatureStringValue);

            var output = Instances.SignatureStringOperator.Get_EventSignatureString(eventSignatureString);
            return output;
        }

        public string Get_SignatureString_ForField(FieldSignature fieldSignature)
        {
            var declaringTypeSignatureStringValue = this.Get_SignatureStringValue_ForType(fieldSignature.DeclaringType);
            var typeSignatureStringValue = this.Get_SignatureStringValue_ForType(fieldSignature.Type);

            var fieldSignatureString = Instances.SignatureStringOperator.Combine(
                declaringTypeSignatureStringValue,
                fieldSignature.FieldName);

            fieldSignatureString = Instances.SignatureStringOperator.Append_OutputType(
                fieldSignatureString,
                typeSignatureStringValue);

            var output = Instances.SignatureStringOperator.Get_FieldSignatureString(fieldSignatureString);
            return output;
        }

        public string Get_SignatureString_ForMethod(MethodSignature methodSignature)
        {
            var declaringTypeSignatureStringValue = this.Get_SignatureStringValue_ForType(methodSignature.DeclaringType);
            var returnTypeSignatureStringValue = this.Get_SignatureStringValue_ForType(methodSignature.ReturnType);

            var methodNameSignatureString = Instances.SignatureStringOperator.Combine(
                declaringTypeSignatureStringValue,
                methodSignature.MethodName);

            var genericTypeInputsList = this.Get_GenericTypeInputsList(methodSignature.GenericTypeInputs);

            methodNameSignatureString = Instances.SignatureStringOperator.Append_TypeParameterList(
                methodNameSignatureString,
                genericTypeInputsList);

            var parametersList = this.Get_ParametersList(methodSignature.Parameters);

            methodNameSignatureString = Instances.SignatureStringOperator.Append_ParameterList(
                methodNameSignatureString,
                parametersList);

            methodNameSignatureString = Instances.SignatureStringOperator.Append_OutputType(
                methodNameSignatureString,
                returnTypeSignatureStringValue);

            var output = Instances.SignatureStringOperator.Get_MethodSignatureString(methodNameSignatureString);
            return output;
        }

        public string Get_SignatureString_ForProperty(PropertySignature propertySignature)
        {
            var declaringTypeSignatureStringValue = this.Get_SignatureStringValue_ForType(propertySignature.DeclaringType);
            var typeSignatureStringValue = this.Get_SignatureStringValue_ForType(propertySignature.Type);

            var propertyNameSignatureString = Instances.SignatureStringOperator.Combine(
                declaringTypeSignatureStringValue,
                propertySignature.PropertyName);

            // For properties, if there are no parameters, there is no parameter list open-close parenthesis pair.
            var anyParameters = propertySignature.Parameters.Any();

            var parametersList = anyParameters
                ? this.Get_ParametersList(propertySignature.Parameters)
                : Instances.Strings.Empty
                ;   

            propertyNameSignatureString = Instances.SignatureStringOperator.Append_ParameterList(
                propertyNameSignatureString,
                parametersList);

            propertyNameSignatureString = Instances.SignatureStringOperator.Append_OutputType(
                propertyNameSignatureString,
                typeSignatureStringValue);

            var output = Instances.SignatureStringOperator.Get_PropertySignatureString(propertyNameSignatureString);
            return output;
        }

        public string Get_SignatureString_ForType(TypeSignature typeSignature)
        {
            var typeSignatureStringValue = this.Get_SignatureStringValue_ForType(typeSignature);

            var output = Instances.SignatureStringOperator.Get_TypeSignatureString(typeSignatureStringValue);
            return output;
        }

        public string Get_SignatureStringValue_ForType(TypeSignature typeSignature)
        {
            string typeIdentityString;

            if (typeSignature.Is_Nested)
            {
                var parentTypeSignature = this.Get_SignatureStringValue_ForType(typeSignature.NestedTypeParent);

                typeIdentityString = Instances.SignatureStringOperator.Append_NestedTypeTypeName(
                    parentTypeSignature,
                    typeSignature.TypeName);
            }
            else
            {
                if(typeSignature.Is_GenericTypeParameter)
                {
                    typeIdentityString = $"{Instances.TypeNameAffixes.TypeParameterMarker_Prefix}{typeSignature.TypeName}";
                }
                else if(typeSignature.Is_GenericMethodParameter)
                {
                    typeIdentityString = $"{Instances.TypeNameAffixes.MethodTypeParameterMarker_Prefix}{typeSignature.TypeName}";
                }
                else
                {
                    typeIdentityString = Instances.SignatureStringOperator.Combine(
                        typeSignature.NamespaceName,
                        typeSignature.TypeName);
                }
            }

            // No need to check if null or empty; if so, an empty string will be returned.
            var genericTypeInputsList = this.Get_GenericTypeInputsList(typeSignature.GenericTypeInputs);

            var output = Instances.SignatureStringOperator.Append_TypeParameterList(
                typeIdentityString,
                genericTypeInputsList);

            return output;
        }

        /// <summary>
        /// Note: can handle the null and empty case (returns an empty string).
        /// </summary>
        public string Get_ParametersList(MethodParameter[] parameters = default)
        {
            var isDefault = parameters == default;
            if (isDefault)
            {
                parameters = Instances.ArrayOperator.Empty<MethodParameter>();
            }

            var anyParameters = parameters.Any();

            var parameterListValue = anyParameters
                ? parameters
                    .Select(parameter => this.Get_ParameterToken(parameter))
                    .Join(Instances.TokenSeparators.ArgumentListSeparator)
                // Parameter lists will always have an open and close parenthesis pair, even if empty.
                : String.Empty
                ;

            var output = parameterListValue.Wrap(
                    Instances.TokenSeparators.ParameterListOpenTokenSeparator,
                    Instances.TokenSeparators.ParameterListCloseTokenSeparator);

            return output;
        }

        public string Get_ParameterToken(MethodParameter parameter)
        {
            var parameterTypeIdentityString = this.Get_SignatureStringValue_ForType(parameter.ParameterType);

            var output = Instances.SignatureStringOperator.Append_ParameterName(
                parameterTypeIdentityString,
                parameter.ParameterName);

            return output;
        }

        /// <summary>
        /// Note: can handle the null and empty case (returns an empty string).
        /// </summary>
        public string Get_GenericTypeInputsList(TypeSignature[] genericTypeInputs = default)
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

            var output = genericTypeInputs
                .Select(genericTypeInput => this.Get_SignatureStringValue_ForType(genericTypeInput))
                .Join(Instances.TokenSeparators.ArgumentListSeparator)
                .Wrap(
                    Instances.TokenSeparators.TypeArgumentListOpenTokenSeparator,
                    Instances.TokenSeparators.TypeArgumentListCloseTokenSeparator);

            return output;
        }
    }
}
