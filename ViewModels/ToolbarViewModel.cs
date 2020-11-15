using System;
using System.Collections.Generic;
using System.Text;
using DrongoAI.Models;
using System.Collections.ObjectModel;
using System.Windows;

namespace DrongoAI.ViewModels
{
    public class ToolbarViewModel
    {
        private MainWindowsViewModel _mainvm;
        public Toolbar toolbar { get; set; }
        public ICommandImpl createShape { get; set; }
        public ICommandImpl changeSize { get; set; }
        public ICommandImpl changeColor { get; set; }
        public ICommandImpl drawShape { get; set; }
        public ICommandImpl removeShape { get; set; }

        public ToolbarViewModel(MainWindowsViewModel mainvm)
        {
            _mainvm = mainvm;
            toolbar = new Toolbar { isShapeSelected = false, isDrawModeSelected = false };
            createShape = new ICommandImpl(obj => CreateShape((string)obj));
            changeSize = new ICommandImpl(obj => ChangeShapeSize((string)obj));
            changeColor = new ICommandImpl(obj => ChangeShapeColor((string)obj));
            drawShape = new ICommandImpl(obj => DrawShape());
            removeShape = new ICommandImpl(obj => RemoveShape());
        }

        private void CreateShape(string shapeType)
        {
            _mainvm.canvasVM.CreateShape(shapeType);
        }

        private void ChangeShapeSize(string operation)
        {
            _mainvm.canvasVM.ChangeShangeSize(operation);
        }

        private void ChangeShapeColor(string color)
        {
            _mainvm.canvasVM.ChangeShapeColor(color);
        }

        private void DrawShape()
        {
            toolbar.isDrawModeSelected = !toolbar.isDrawModeSelected;
            _mainvm.canvasVM.DrawShape();
            if (_mainvm.selEl == null)
            { toolbar.isShapeSelected = false; }
        }

        private void RemoveShape()
        {
            _mainvm.canvasVM.RemoveShape();
        }
    }
}
