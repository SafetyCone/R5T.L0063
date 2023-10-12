using System;
using System.Linq;
using System.Reflection;

using R5T.T0132;


namespace R5T.L0063.F001.Platform
{
    [FunctionalityMarker]
    public partial interface IMemberInfoOperator : IFunctionalityMarker,
        L0053.IMemberInfoOperator
    {
        private static L0053.IMemberInfoOperator Base => L0053.MemberInfoOperator.Instance;


        public string Get_SignatureString(MemberInfo memberInfo)
        {
            var output = memberInfo switch
            {
                ConstructorInfo constructorInfo => this.Get_SignatureString_ForMethodBase(constructorInfo),
                EventInfo eventInfo => this.Get_SignatureString_ForEvent(eventInfo),
                FieldInfo fieldInfo => this.Get_SignatureString_ForField(fieldInfo),
                MethodInfo methodInfo => this.Get_SignatureString_ForMethodInfo(methodInfo),
                PropertyInfo propertyInfo => this.Get_SignatureString_ForProperty(propertyInfo),
                TypeInfo typeInfo => this.Get_SignatureString_ForTypeInfo(typeInfo),
                _ => throw Instances.ExceptionOperator.Get_UnrecognizedMemberTypeException(memberInfo),
            };

            return output;
        }

        public string Get_SignatureString_ForEvent(EventInfo eventInfo)
        {
            var namespacedTypedName = this.Get_NamespacedTypedName(eventInfo);

            // Append the event handler delegate type as the output type of the event.
            var eventHandlerType = Instances.EventInfoOperator.Get_EventHandlerType(eventInfo);

            var eventHandlerNamespacedTypeName = Instances.TypeOperator.Get_NamespacedTypeName(eventHandlerType);

            var eventSignatureStringValue = Instances.SignatureStringOperator._Platform.Append_OutputType(
                namespacedTypedName,
                eventHandlerNamespacedTypeName);

            var signatureStringValue = this.Append_Obsolete_IfObsolete(
                eventInfo,
                eventSignatureStringValue);

            var output = Instances.SignatureStringOperator._Platform.Get_EventSignatureString(signatureStringValue);
            return output;
        }

        public string Get_SignatureString_ForField(FieldInfo fieldInfo)
        {
            var namespacedTypedName = this.Get_NamespacedTypedName(fieldInfo);

            var typeSignatureStringValue = Instances.TypeOperator.Get_NamespacedTypeName(fieldInfo.FieldType);

            var fieldSignatureStringValue = Instances.SignatureStringOperator._Platform.Append_OutputType(
                namespacedTypedName,
                typeSignatureStringValue);

            var signatureStringValue = this.Append_Obsolete_IfObsolete(
                fieldInfo,
                fieldSignatureStringValue);

            var output = Instances.SignatureStringOperator._Platform.Get_FieldSignatureString(signatureStringValue);
            return output;
        }

        public string Get_SignatureString_ForMethodInfo(MethodInfo methodInfo)
        {
            var methodBaseSignatureString = this.Get_SignatureString_ForMethodBase(methodInfo);

            // Append the return type.
            var returnTypeName = Instances.TypeOperator.Get_NamespacedTypeName(methodInfo.ReturnType);

            var methodSignatureString = Instances.SignatureStringOperator._Platform.Append_OutputType(
                methodBaseSignatureString,
                returnTypeName);

            var output = this.Append_Obsolete_IfObsolete(
                methodInfo,
                methodSignatureString);

            return output;
        }

        public string Get_SignatureString_ForMethodBase(MethodBase methodBase)
        {
            var namespacedTypedName = this.Get_NamespacedTypedName(methodBase);

            var methodName = namespacedTypedName;

            // Handle method generic type parameters.
            var isGeneric = Instances.MethodBaseOperator.Is_Generic(methodBase);
            if (isGeneric)
            {
                var genericTypeArguments = Instances.MethodBaseOperator.Get_GenericTypeParameters(methodBase);

                var typeParametersListToken = Instances.TypeOperator.Get_TypeNameListToken(genericTypeArguments);

                methodName = Instances.SignatureStringOperator._Platform.Append_TypeParameterList(
                    methodName,
                    typeParametersListToken);
            }

            // Need to account for parameter types.
            try
            {
                // This fails on pointer types.
                var parametersPart = this.Get_ParametersPart(methodBase);

                methodName = Instances.SignatureStringOperator._Platform.Append(
                    methodName,
                    parametersPart);
            }
            // Function pointers are not supported.
            catch (NotSupportedException)
            {
                // Do nothing.
            }

            // No return type for method bases.

            // No obsolete token for method bases (will be added in method- and constructor-specific callers, since they need to add output types).

            var output = Instances.SignatureStringOperator._Platform.Get_MethodSignatureString(methodName);
            return output;
        }

        public string Get_SignatureString_ForProperty(PropertyInfo propertyInfo)
        {
            var namespacedTypedName = this.Get_NamespacedTypedName(propertyInfo);

            var propertyName = namespacedTypedName;

            var isIndexer = Instances.PropertyInfoOperator.Is_Indexer(propertyInfo);
            if (isIndexer)
            {
                var parameterInfos = Instances.PropertyInfoOperator.Get_IndexerParameters(propertyInfo);

                var parametersPart = this.Get_ParametersPart(parameterInfos);

                propertyName = Instances.SignatureStringOperator._Platform.Append(
                    propertyName,
                    parametersPart);
            }

            var typeNamespacedTypeName = Instances.TypeOperator.Get_NamespacedTypeName(propertyInfo.PropertyType);

            propertyName = Instances.SignatureStringOperator._Platform.Append_OutputType(
                propertyName,
                typeNamespacedTypeName);

            var signatureStringValue = this.Append_Obsolete_IfObsolete(
                propertyInfo,
                propertyName);

            var output = Instances.SignatureStringOperator._Platform.Get_PropertySignatureString(signatureStringValue);
            return output;
        }

        public string Get_SignatureString_ForTypeInfo(TypeInfo typeInfo)
        {
            var output = this.Get_SignatureString_ForType(typeInfo);
            return output;
        }

        public string Get_SignatureString_ForType(Type type)
        {
            var namespacedTypeName = Instances.TypeOperator.Get_NamespacedTypeName(type);

            var signatureStringValue = this.Append_Obsolete_IfObsolete(
                type,
                namespacedTypeName);

            var output = Instances.SignatureStringOperator._Platform.Get_TypeSignatureString(signatureStringValue);
            return output;
        }

        /// <summary>
        /// If the member is obsolete (<see cref="L0053.IMemberInfoOperator.Is_Obsolete(MemberInfo)"/>), append the 
        /// </summary>
        public string Append_Obsolete_IfObsolete(
            MemberInfo memberInfo,
            string signatureString)
        {
            var isObsolete = this.Is_Obsolete(memberInfo);

            var output = isObsolete
                ? Instances.SignatureStringOperator.Append_ObsoleteToken(signatureString)
                : signatureString
                ;

            return output;
        }

        /// <summary>
        /// Gets the name of a member, adjusted by <see cref="Adjust_MemberName(string)"/>.
        /// <para><inheritdoc cref="Adjust_MemberName(string)" path="/summary"/></para>
        /// </summary>
        public new string Get_Name(MemberInfo memberInfo)
        {
            // Get the name of the member.
            var memberName = Base.Get_Name(memberInfo);

            // Now adjust the name for the signature string rules.
            var output = this.Adjust_MemberName(memberName);
            return output;
        }

        public string Get_NamespacedTypedName(MemberInfo memberInfo)
        {
            var namespacedTypeName = Instances.TypeOperator.Get_NamespacedTypeName(memberInfo.DeclaringType);
            var memberName = this.Get_Name(memberInfo);

            var output = Instances.SignatureStringOperator._Platform.Combine(namespacedTypeName, memberName);
            return output;
        }

        /// <summary>
        /// Adjusts the name of a member for:
        /// 1) Whether the member is explicitly implemented.
        /// </summary>
        public string Adjust_MemberName(string memberName)
        {
            var output = memberName;

            //// Tuple-craziness!
            //// In: C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\6.0.21\ref\net6.0\System.Collections.dll
            //// Desired: M:System.Collections.Generic.PriorityQueue`2.UnorderedItemsCollection.System#Collections#Generic#IEnumerable{System#ValueTuple{TElement@TPriority}}#GetEnumerator
            //// Result: M:System.Collections.Generic.PriorityQueue`2.UnorderedItemsCollection.System#Collections#Generic#IEnumerable{(TElementElement@TPriorityPriority)}#GetEnumerator
            //var containsTuple = output.Contains('(');
            //if(containsTuple)
            //{
            //    var declaringType = memberInfo.DeclaringType;

            //    var declaringTypeInterfaceTypes = declaringType.GetInterfaces();
            //    foreach (var interfaceType in declaringTypeInterfaceTypes)
            //    {
            //        // Fails with exception: System.NotSupportedException: 'InterfaceMapping is not supported on assemblies loaded by a MetadataLoadContext.'
            //        var interfaceMap = declaringType.GetInterfaceMap(interfaceType);

            //        var interfaceContainsMember = interfaceMap.TargetMethods.Contains(memberInfo);
            //        if(interfaceContainsMember)
            //        {
            //            var containingInterfaceType = interfaceMap.InterfaceType;

            //            output = containingInterfaceType.Name;

            //            break;
            //        }
            //    }
            //}

            // Convert all namespace token separators ('.', periods) to hashes ('#').
            output = Instances.StringOperator.Replace(
                output,
                newCharacter: Instances.TokenSeparators.ExplicitImplementationNamespaceTokenSeparator,
                Instances.TokenSeparators.NamespaceTokenSeparator);

            // Convert all generic type list open token separators ('<', periods) to open braces ('{').
            output = Instances.StringOperator.Replace(
                output,
                newCharacter: '{',
                Instances.TokenSeparators.GenericTypeListOpenTokenSeparator);

            // Convert all generic type list close token separators ('>', periods) to close braces ('}').
            output = Instances.StringOperator.Replace(
                output,
                newCharacter: '}',
                Instances.TokenSeparators.GenericTypeListCloseTokenSeparator);

            return output;
        }

        public string Get_ParametersPart(MethodBase methodBase)
        {
            var parameters = Instances.MethodBaseOperator.Get_Parameters(methodBase);

            var output = this.Get_ParametersPart(parameters);
            return output;
        }

        /// <summary>
        /// For signature strings, even if there are no parameters, there will still be an empty parenthesis pair.
        /// </summary>
        public string Get_ParametersPart(ParameterInfo[] parameters)
        {
            var anyParameters = parameters.Any();

            var parametersListValue = anyParameters
                ? Instances.StringOperator.Join(
                    Instances.TokenSeparators.ArgumentListSeparator,
                    parameters.Select(parameter =>
                    {
                        var parameterType = Instances.ParameterInfoOperator.Get_NamespacedTypeName_OfParameterType(parameter);

                        var parameterHasName = Instances.StringOperator.Is_NotNullOrEmpty(parameter.Name);

                        var parameterName = parameterHasName
                            ? parameter.Name
                            : "parameter"
                            ;

                        var output = $"{parameterType}{Instances.TokenSeparators.ParameterNameTokenSeparator}{parameterName}";
                        return output;
                    })
                )
                // There will still be an empty parenthesis pair.
                : String.Empty
                ;

            // Add an open-close parenthesis pair no matter what.
            var output = $"{Instances.TokenSeparators.ParameterListOpenTokenSeparator}{parametersListValue}{Instances.TokenSeparators.ParameterListCloseTokenSeparator}";
            return output;
        }
    }
}
