﻿using ShapeLibrary.Exeptions;
using ShapeLibrary.Parsers.Contexts;
using ShapeLibrary.Parsers.States.BaseStates;

namespace ShapeLibrary.Parsers.States.CircleStates;

public class CircleCommaState : BaseState
{
    //смотрит что б была запятая, иначе косяк
    protected override void CheckMatching(IContext context)
    {
        if (context.Position >= context.ShapeStringRepresentation.Length)
        {
            throw new InvalidCharacterExeption(context.ShapeStringRepresentation, context.Position, "\',\'");
        }

        if (context.ShapeStringRepresentation[context.Position] != ',')
        {
            throw new InvalidCharacterExeption(context.ShapeStringRepresentation, context.Position, "\',\'");
        }

        ++context.Position;
    }

    //фуууу переопределение фуууу, но тут создается объект другого класса
    protected override void ChangeState(IContext context)
    {
        context.State = new CircleRadiusState();
    }
}