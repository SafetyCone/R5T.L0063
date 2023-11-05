using System;
using System.Collections.Generic;
using System.Linq;

using R5T.L0053.Extensions;

using R5T.L0063.F000.Extensions;


namespace R5T.L0063.F000
{
    public partial interface ISignatureStringOperator
    {
        //var indexOfOpenTokenSeparator_OrNotFound = Instances.StringOperator.Get_IndexOf_OrNotFound(
        //    typedSignatureString,
        //    Instances.TokenSeparators.GenericTypeListOpenTokenSeparator);

        //var isFound = Instances.StringOperator.Is_Found(indexOfOpenTokenSeparator_OrNotFound);
        //if (isFound)
        //{
        //    // Even if the generic type list open token is found, if it found at the start of the typed signature string,
        //    // or immediately following a namespace token separator or nested type token separator, then it is part of a compiler generated name.
        //    var isFirst = Instances.IndexOperator.Is_First(indexOfOpenTokenSeparator_OrNotFound);
        //    if(isFirst)
        //    {
        //        // We have a compiler-generated type name like <>c__DisplayClass0_0.
        //        return false;
        //    }

        //    var precedingCharacter = Instances.StringOperator.Get_Character(
        //        typedSignatureString,
        //        indexOfOpenTokenSeparator_OrNotFound - 1);

        //    var precedingCharacterIsNameTokenSeparator = false
        //        || Instances.TokenSeparators.NestedTypeNameTokenSeparator == precedingCharacter
        //        || Instances.TokenSeparators.NamespaceTokenSeparator == precedingCharacter
        //        ;

        //    if(precedingCharacterIsNameTokenSeparator)
        //    {
        //        // If the preceding character is a name token separator, then we have one of the compiler generated type names like "D8S.C0002.Deploy.IOperations+<>c__DisplayClass0_0".
        //        return false;
        //    }

        //    // Else, true.
        //    return true;
        //}
        //else
        //{
        //    // If the generic type list open token separator is not found, then the typed signature string definitely does not have a generic inputs list.
        //    return false;
        //}
    }
}
