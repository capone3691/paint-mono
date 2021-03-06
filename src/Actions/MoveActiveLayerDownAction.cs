/////////////////////////////////////////////////////////////////////////////////
// Paint.NET                                                                   //
// Copyright (C) Rick Brewster, Tom Jackson, and past contributors.            //
// Portions Copyright (C) Microsoft Corporation. All Rights Reserved.          //
// See src/Resources/Files/License.txt for full licensing and attribution      //
// details.                                                                    //
// .                                                                           //
/////////////////////////////////////////////////////////////////////////////////

using PaintDotNet.HistoryMementos;
using System;

namespace PaintDotNet.Actions
{
    public sealed class MoveActiveLayerDownAction
        : DocumentWorkspaceAction
    {
        public static string StaticName
        {
            get
            {
                return PdnResources.GetString("MoveLayerDown.HistoryMementoName");
            }
        }

        public static ImageResource StaticImage
        {
            get
            {
                return ImageResource.Get("Icons.MenuLayersMoveLayerDownIcon.png");
            }
        }

        public override HistoryMemento PerformAction(DocumentWorkspace documentWorkspace)
        {
            HistoryMemento hm = null;
            int index = documentWorkspace.ActiveLayerIndex;

            if (index != 0)
            {
                SwapLayerHistoryMemento slhm = new SwapLayerHistoryMemento(
                    StaticName,
                    StaticImage,
                    documentWorkspace,
                    index,
                    index - 1);

                hm = slhm.PerformUndo();
            }

            return hm;
        }

        public MoveActiveLayerDownAction()
            : base(ActionFlags.None)
        {
        }
    }
}
