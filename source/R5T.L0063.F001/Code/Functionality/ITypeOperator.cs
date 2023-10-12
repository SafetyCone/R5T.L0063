using System;
using System.Collections.Generic;
using System.Linq;

using R5T.T0132;


namespace R5T.L0063.F001
{
    [FunctionalityMarker]
    public partial interface ITypeOperator : IFunctionalityMarker,
        L0053.ITypeOperator
    {
        private static L0053.ITypeOperator Base => L0053.TypeOperator.Instance;


        /// <summary>
        /// Returns the namespaced type name, with a slight difference relative to <see cref="L0053.ITypeOperator.Get_NamespacedTypeName(Type)"/>.
        /// <para><inheritdoc cref="Get_TypeName(Type)" path="/descendant::the-difference"/></para>
        /// </summary>
        public new string Get_NamespacedTypeName(Type type)
        {
            var typeName = this.Get_TypeName(type);

            // If the type is a generic parameter, then just return the type name of the generic parameter.
            var isGenericParameter = this.Is_GenericParameter(type);
            if(isGenericParameter)
            {
                return typeName;
            }
            else
            {
                var isNestedType = this.Is_NestedType(type);
                if(isNestedType)
                {
                    var parentType = this.Get_NestedTypeParentType(type);

                    var parentNamespacedTypeName = this.Get_NamespacedTypeName(parentType);

                    var output = Instances.SignatureStringOperator._Platform.Append_NestedTypeTypeName(
                        parentNamespacedTypeName,
                        typeName);

                    return output;
                }
                else
                {
                    var namespaceName = this.Get_NamespaceName(type);

                    var output = Instances.NamespacedTypeNameOperator.Get_NamespacedTypeName(
                        namespaceName,
                        typeName);

                    return output;
                }
            }
        }

        /// <summary>
        /// Returns the simple type name, with a slight difference relative to <see cref="L0053.ITypeOperator.Get_Name(Type)"/>.
        /// <para>
        /// <the-difference>
        /// The difference is that generic types do not use position-based name for generic type parameter type names (example: "`1"),
        /// but instead use the actual name of the generic type parameter (example: "T").
        /// </the-difference>
        /// </para>
        /// </summary>
        public new string Get_TypeName(Type type)
        {
            // If the type has an element-type (because the type is an array, or by-reference, etc.),
            // then get the type name for the underlying type, then append the type name affix for the element-type relationship.
            var hasElementType = this.Has_ElementType(type);
            if(hasElementType)
            {
                // Get the type name for the element type.
                var elementType = this.Get_ElementType(type);

                var elementTypeName = this.Get_TypeName(elementType);

                // Then append the element relationship marker type-name affix for the given relationship,
                // using the default type name affixes.
                var output = Instances.TypeNameOperator.Append_ElementTypeRelationshipMarker(
                    type,
                    elementTypeName);

                return output;
            }

            // If the type is a generic parameter type (either a generic type parameter type, or generic method parameter type), return its actual name.
            var isGenericParameter = this.Is_GenericParameter(type);
            if (isGenericParameter)
            {
                var genericTypeParameterActualName = this.Get_GenericTypeParameterTypeName_ActualName(type);

                var isGenericTypeParameter = this.Is_GenericTypeParameter(type);

                var output = isGenericTypeParameter
                    ? Instances.TypeNameOperator.Get_GenericTypeParameterMarkedTypeName(genericTypeParameterActualName)
                    : Instances.TypeNameOperator.Get_GenericMethodParameterMarkedTypeName(genericTypeParameterActualName)
                    ;

                return output;
            }

            // Start with the base type name.
            var typeNameWithGenericTypeParameterCount = Base.Get_Name(type);

            // Remove the generic type parameter count.
            var typeName = Instances.TypeNameOperator.Remove_GenericTypeParameterCount_IfPresent(typeNameWithGenericTypeParameterCount);

            // If the type is a generic type definition (example: IList<> (a.k.a IList<T>), with no type arguments specified),
            // or a constructed generic type (example: IList<string>, with type arguments specified)
            // then we will want to create a type parameters list using the angle-bracket token separators.
            var genericTypeParameters = this.Get_GenericTypeParameterTypes(type);
            if(genericTypeParameters.Any())
            {
                var typeParametersListToken = this.Get_TypeNameListToken(genericTypeParameters);

                var output = Instances.SignatureStringOperator._Platform.Append_TypeParameterList(
                    typeName,
                    typeParametersListToken);

                return output;
            }

            var isGenericType = this.Is_ConstructedGeneric(type);
            if (isGenericType)
            {
                var genericTypeArguments = this.Get_GenericTypeArguments(type);

                var typeParametersListToken = this.Get_TypeNameListToken(genericTypeArguments);

                var output = Instances.SignatureStringOperator._Platform.Append_TypeParameterList(
                    typeName,
                    typeParametersListToken);

                return output;
            }

            // Else, just use the regular type name.
            {
                var output = typeName;
                return output;
            }
        }

        public string Get_TypeNameListValue(IEnumerable<Type> types)
        {
            var namespacedTypeNames = types
                .Select(type => this.Get_NamespacedTypeName(type))
                ;

            var output = Instances.StringOperator.Join(
                Instances.TokenSeparators.ArgumentListSeparator,
                namespacedTypeNames);

            return output;
        }

        public string Get_TypeNameListToken(IEnumerable<Type> types)
        {
            // Short circuit if empty.
            var any = types.Any();
            if(!any)
            {
                return String.Empty;
            }
            
            // Else, if there are some types, make the list.
            var typeNameListValue = this.Get_TypeNameListValue(types);

            var output = $"{Instances.TokenSeparators.TypeArgumentListOpenTokenSeparator}{typeNameListValue}{Instances.TokenSeparators.TypeArgumentListCloseTokenSeparator}";
            return output;
        }
    }
}
