using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MetaphysicsIndustries.Crystalline;
using MetaphysicsIndustries.Collections;
using MetaphysicsIndustries.Acuity;
using System.Drawing.Imaging;

namespace MetaphysicsIndustries.Amethyst
{
    public partial class AmethystControl : CrystallineControl
    {
        ToolStripMenuItem _addItem = new ToolStripMenuItem("Add");
        public ToolStripMenuItem AddItem
        {
            get { return _addItem; }
        }

        //ToolStripMenuItem _addLiteralItem = new ToolStripMenuItem("Literal");
        //ToolStripMenuItem _addStringLiteralItem = new ToolStripMenuItem("String");
        //ToolStripMenuItem _addIntegerLiteralItem = new ToolStripMenuItem("Integer");
        //ToolStripMenuItem _addDoubleLiteralItem = new ToolStripMenuItem("Double");

        //ToolStripMenuItem _addWindowProcessorItem = new ToolStripMenuItem("Window Processor");
        //ToolStripMenuItem _addAlphaTrimItem = new ToolStripMenuItem("Alpha Trim");
        //ToolStripMenuItem _addZetaTrimItem = new ToolStripMenuItem("Zeta Trim");

        //ToolStripMenuItem _addWindowCalculationItem = new ToolStripMenuItem("Window Calculation");
        //ToolStripMenuItem _addAveragerItem = new ToolStripMenuItem("Mean");
        //ToolStripMenuItem _addVarianceCalculatorItem = new ToolStripMenuItem("Variance");
        //ToolStripMenuItem _addHistogramFilterItem = new ToolStripMenuItem("Histogram");
        //ToolStripMenuItem _addCalcIntervalItem = new ToolStripMenuItem("Interval");

        //ToolStripMenuItem _addFilterItem = new ToolStripMenuItem("Filter");
        //ToolStripMenuItem _addImpulseFilterItem = new ToolStripMenuItem("Impulse Noise");
        //ToolStripMenuItem _addFilterApplyItem = new ToolStripMenuItem("Filter Apply");
        //ToolStripMenuItem _addMeanFilterItem = new ToolStripMenuItem("Mean Filter");
        //ToolStripMenuItem _addSobelFilterItem = new ToolStripMenuItem("Sobel Filter");
        //ToolStripMenuItem _addDualBellFilterItem = new ToolStripMenuItem("Dual Bell Filter");
        //ToolStripMenuItem _addAlphaTrimDualBellFilterItem = new ToolStripMenuItem("Alpha Trimmed Dual Bell Filter");
        //ToolStripMenuItem _addIntervalFitFilterItem = new ToolStripMenuItem("Interval Fit");
        //ToolStripMenuItem _addIntervalFit2FilterItem = new ToolStripMenuItem("Interval Fit 2");
        //ToolStripMenuItem _addNegOneOneFitFilterItem = new ToolStripMenuItem("[-1,1] -> [0,1]");
        //ToolStripMenuItem _addRgbToHslItem = new ToolStripMenuItem("RGB -> HSL");
        //ToolStripMenuItem _addSlicerItem = new ToolStripMenuItem("Matrix.GetSlice");

        //ToolStripMenuItem _addFilterGeneratorItem = new ToolStripMenuItem("Filter Generator");
        //ToolStripMenuItem _addImpulseNoiseFilterGeneratorItem = new ToolStripMenuItem("Impulse Noise");
        //ToolStripMenuItem _addGaussianNoiseFilterGeneratorItem = new ToolStripMenuItem("Gaussian Noise");
        //ToolStripMenuItem _addMedianFilterGeneratorItem = new ToolStripMenuItem("Median");
        //ToolStripMenuItem _addExpandEdgeFilterGeneratorItem = new ToolStripMenuItem("Expand Edge");

        //ToolStripMenuItem _addDebugItem = new ToolStripMenuItem("Debug");
        //ToolStripMenuItem _addAllInItem = new ToolStripMenuItem("All In");
        //ToolStripMenuItem _addAllOutItem = new ToolStripMenuItem("All Out");
        //ToolStripMenuItem _addTextItem = new ToolStripMenuItem("Text");
        //ToolStripMenuItem _addAluItem = new ToolStripMenuItem("ALU");
        //ToolStripMenuItem _addMuxItem = new ToolStripMenuItem("MUX");
        //ToolStripMenuItem _addMultItem = new ToolStripMenuItem("Mult");

        //ToolStripMenuItem _addDisplayItem = new ToolStripMenuItem("Display");
        //ToolStripMenuItem _addImageDisplay = new ToolStripMenuItem("Image");
        //ToolStripMenuItem _addStringDisplayItem = new ToolStripMenuItem("String");
        //ToolStripMenuItem _addDoubleDisplayItem = new ToolStripMenuItem("Double");
        //ToolStripMenuItem _addIntegerDisplayItem = new ToolStripMenuItem("Integer");

        //ToolStripMenuItem _addMeasureItem = new ToolStripMenuItem("Measure");
        //ToolStripMenuItem _addMssimItem = new ToolStripMenuItem("Mssim");
        //ToolStripMenuItem _addMseItem = new ToolStripMenuItem("Mse");

        //ToolStripMenuItem _addOpenFilenameItem = new ToolStripMenuItem("Open Filename");
        //ToolStripMenuItem _addSaveFilenameItem = new ToolStripMenuItem("Save Filename");
        //ToolStripMenuItem _addLoadImageItem = new ToolStripMenuItem("Load Image");
        //ToolStripMenuItem _addSaveImageItem = new ToolStripMenuItem("Save Image");
        //ToolStripMenuItem _addLoadColorImageItem = new ToolStripMenuItem("Load Color Image");
        //ToolStripMenuItem _addMatrixConvolutionItem = new ToolStripMenuItem("Matrix Convolution");
        //ToolStripMenuItem _addMmseItem = new ToolStripMenuItem("MMSE");
        //ToolStripMenuItem _addToStringItem = new ToolStripMenuItem("ToString()");

        //ToolStripMenuItem _

        ToolStripMenuItem _connectItem = new ToolStripMenuItem("Connect");
        ToolStripMenuItem _disconnectItem = new ToolStripMenuItem("Disconnect");
        ToolStripMenuItem _executeItem = new ToolStripMenuItem("Execute");
        ToolStripMenuItem _executeAsyncItem = new ToolStripMenuItem("Execute Async");
        ToolStripMenuItem _deleteItem = new ToolStripMenuItem("Delete");

        ToolStripSeparator _separator = new ToolStripSeparator();

        protected override void SetupContextMenuItems()
        {
            ContextMenuStrip.Items.Add(_addItem);


            AddSolusItems(AddItem);
            AddZirconiaItems(AddItem);

            AddSectionSeparator();

            AddLiteralItems(AddItem);
            AddDisplayItems(AddItem);
            AddFileItems(AddItem);
            AddMathItems(AddItem);
            AddDebugItems(AddItem);
            AddMenuItemForElement<ToStringElement>("ToString()", AddItem);
            AddMenuItemForElement<TypeofElement>("typeof()", AddItem);
            AddMenuItemForElement<FeedbackElement>("Feedback Loop", AddItem);
            AddMenuItemForElement<NestedElement>("Nested Node", AddItem);

            //AddMenuItemForElement<InputTerminalElement>("External Input", AddItem);
            //AddMenuItemForElement<OutputTerminalElement>("External Output", AddItem);
            //AddMenuItemForElement<NodeElementConverterNode.NodeElementConverterElement>("Node-Element Converter", AddItem);
            //AddMenuItem(AddItem, new ToolStripMenuItem("Node Source"), new EventHandler(NodeSourceItem_Click));


            AddMenuItem(ContextMenuStrip, _connectItem, new EventHandler(ConnectItem_Click));
            AddMenuItem(ContextMenuStrip, _disconnectItem, new EventHandler(DisconnectItem_Click));
            ContextMenuStrip.Items.Add(new ToolStripSeparator());
            AddMenuItem(ContextMenuStrip, _executeItem, new EventHandler(ExecuteItem_Click));
            AddMenuItem(ContextMenuStrip, _executeAsyncItem, new EventHandler(ExecuteAsyncItem_Click));
            ContextMenuStrip.Items.Add(new ToolStripSeparator());
            AddMenuItem(ContextMenuStrip, _deleteItem, new EventHandler(DeleteItem_Click2));
            ContextMenuStrip.Items.Add(new ToolStripSeparator());
            AddMenuItem(ContextMenuStrip, new ToolStripMenuItem("Save as image..."), new EventHandler(SaveAsImageItem_Click));
        }

        private void AddFileItems(ToolStripMenuItem parentMenu)
        {
            ToolStripMenuItem fileMenu = CreateMenu("File", parentMenu);
            AddMenuItemForElement<GetOpenFilenameElement>("Open Filename", fileMenu);
            AddMenuItemForElement<GetSaveFilenameElement>("Save Filename", fileMenu);
            AddMenuItemForElement<LoadTextFileElement>("Load Text File", fileMenu);
            AddMenuItemForElement<SaveTextFileElement>("Save Text File", fileMenu);
        }

        private void AddMathItems(ToolStripMenuItem parentMenu)
        {
            ToolStripMenuItem mathMenu = /**/CreateMenu("Math", /*/(/**/parentMenu);
            AddMenuItemForElement<MultElement>("*", mathMenu);
            AddMenuItemForElement<AddElement>("+", mathMenu);
            AddMenuItemForElement<CosineElement>("cos", mathMenu);
            AddMenuItemForElement<SineElement>("sin", mathMenu);
            AddMenuItemForElement<DegreesToRadiansElement>("deg. to rad.", mathMenu);
            AddMenuItemForElement<RadiansToDegreesElement>("rad. to deg.", mathMenu);
            AddMenuItemForElement<SqrtElement>("sqrt", mathMenu);
        }

        public void NodeSourceItem_Click(object sender, EventArgs e)
        {
            AddElementAtLocation(new NodeElementConverterNode.NodeElementConverterElement(new NodeSourceElement.NodeSourceNode()), LastRightClickInDocument);
        }

        public static void AddMenuItem(ContextMenuStrip menu, ToolStripMenuItem item, EventHandler clickHandler)
        {
            item.Click += clickHandler;
            menu.Items.Add(item);
        }

        public ToolStripMenuItem CreateMenu(string text)
        {
            ToolStripMenuItem menu = new ToolStripMenuItem(text);
            ContextMenuStrip.Items.Add(menu);
            return menu;
        }

        public static ToolStripMenuItem CreateMenu(string text, ToolStripMenuItem parentMenu)
        {
            ToolStripMenuItem newMenu = new ToolStripMenuItem(text);
            parentMenu.DropDownItems.Add(newMenu);
            return newMenu;
        }

        public ToolStripMenuItem CreateSectionMenu(string text)
        {
            ToolStripMenuItem newMenu = new ToolStripMenuItem(text);

            AddSectionSeparator();

            AddItem.DropDownItems.Insert(
                AddItem.DropDownItems.IndexOf(_separator),
                newMenu);

            return newMenu;
        }

        private void AddSectionSeparator()
        {
            if (!_addItem.DropDownItems.Contains(_separator))
            {
                AddItem.DropDownItems.Insert(0, _separator);
            }
        }

        private void AddDebugItems(ToolStripMenuItem parentMenu)
        {
            ToolStripMenuItem newMenu = CreateMenu("Debug", parentMenu);
            AddMenuItemForElement<AllInElement>("All In", newMenu);
            AddMenuItemForElement<AllOutElement>("All Out", newMenu);
            AddMenuItemForElement<TextElement>("Text", newMenu);
            AddMenuItemForElement<AluElement>("ALU", newMenu);
            AddMenuItemForElement<MuxElement>("MUX", newMenu);
            AddMenuItemForElement<MultAluElement>("Mult", newMenu);
            AddMenuItemForElement<OneOutElement>("One Out", newMenu);
        }
        private void AddDisplayItems(ToolStripMenuItem parentMenu)
        {
            ToolStripMenuItem newMenu = CreateMenu("Display", parentMenu);
            AddMenuItemForElement<StringValueDisplayElement>("String", newMenu);
            AddMenuItemForElement<IntegerValueDisplayElement>("Integer", newMenu);
            AddMenuItemForElement<DoubleValueDisplayElement>("Double", newMenu);
        }
        private void AddLiteralItems(ToolStripMenuItem parentMenu)
        {
            ToolStripMenuItem newMenu = CreateMenu("Literal", parentMenu);
            AddMenuItemForElement<StringLiteralElement>("String", newMenu);
            AddMenuItemForElement<IntegerLiteralElement>("Integer", newMenu);
            AddMenuItemForElement<DoubleLiteralElement>("Double", newMenu);
        }

        private void AddSolusItems(ToolStripMenuItem parentMenu)
        {
            ToolStripMenuItem solusMenu = CreateSectionMenu("Solus");

            AddMenuItemForElement<ImageDisplayElement>("Image Display", solusMenu);
            AddMenuItemForElement<ColorImageDisplayElement>("Color Image Display", solusMenu);

            solusMenu.DropDownItems.Add(new ToolStripSeparator());

            AddFilterItems(solusMenu);
            AddNoiseItems(solusMenu);
            AddEdgeDetectorsItems(solusMenu);
            AddLevelsItems(solusMenu);
            AddMatrixOpsItems(solusMenu);
            AddPyramidProcessorItems(solusMenu);
            AddWindowProcessorItems(solusMenu);
            AddWindowCalculationItems(solusMenu);
            AddMeasureItems(solusMenu);

            solusMenu.DropDownItems.Add(new ToolStripSeparator());

            AddMenuItemForElement<LoadImageElement>("Load Image", solusMenu);
            AddMenuItemForElement<LoadColorImageElement>("Load Color Image", solusMenu);
            AddMenuItemForElement<SaveImageElement>("Save Image", solusMenu);

            solusMenu.DropDownItems.Add(new ToolStripSeparator());

            AddMenuItemForElement<MmseAmethystElement>("MMSE", solusMenu);
            AddMenuItemForElement<MatrixConvolutionElement>("Matrix Convolution", solusMenu);
        }

        private void AddNoiseItems(ToolStripMenuItem solusMenu)
        {
            ToolStripMenuItem newMenu = CreateMenu("Noise", solusMenu);

            AddMenuItemForElement<GaussianNoiseMatrixFilterElement>("Gaussian Noise", newMenu);
            AddMenuItemForElement<ImpulseNoiseFilterElement>("Impulse Noise", newMenu);
        }

        private void AddFilterItems(ToolStripMenuItem parentMenu)
        {
            ToolStripMenuItem newMenu = CreateMenu("Filter", parentMenu);
            AddMenuItemForElement<MedianMatrixFilterElement>("Median", newMenu);
            AddMenuItemForElement<GaussianBlurFilterElement>("Gaussian Blur", newMenu);
            AddMenuItemForElement<ArithmeticMeanFilterElement>("Arithmetic Mean", newMenu);
            AddMenuItemForElement<AlphaTrimmedMeanElement>("Alpha-trimmed Mean", newMenu);
            AddMenuItemForElement<ZetaTrimmedMeanElement>("Zeta-trimmed Mean", newMenu);



        }
        private void AddEdgeDetectorsItems(ToolStripMenuItem parentMenu)
        {
            ToolStripMenuItem newMenu = CreateMenu("Edge Detect", parentMenu);

            AddMenuItemForElement<SobelMatrixFilterElement>("Sobel Filter", newMenu);
            AddMenuItemForElement<DualBellMatrixFilterElement>("Dual Bell Filter", newMenu);
            AddMenuItemForElement<AlphaTrimmedDualBellMatrixFilterElement>("Alpha Trimmed Dual Bell Filter", newMenu);
        }

        private void AddLevelsItems(ToolStripMenuItem parentMenu)
        {
            ToolStripMenuItem newMenu = CreateMenu("Levels", parentMenu);

            AddMenuItemForElement<IntervalFitMatrixFilterElement>("Interval Fit", newMenu);
            AddMenuItemForElement<IntervalFit2FilterElement>("Interval Fit 2", newMenu);
            AddMenuItemForElement<NegOneOneToZeroOneFitMatrixFilterElement>("[-1,1] -> [0,1]", newMenu);
            AddMenuItemForElement<ThresholdMatrixFilterElement>("Threshold", newMenu);
            AddMenuItemForElement<AndMatrixFilterElement>("Matrix And", newMenu);
            AddMenuItemForElement<InverterMatrixFilterElement>("Matrix Inverter", newMenu);
            //AddMenuItemForElement<FlattenerFilterElement>("Flattener", newMenu);

            newMenu.DropDownItems.Add(new ToolStripSeparator());

            AddMenuItemForElement<RgbToHslConverterElement>("RGB -> HSL", newMenu);
            AddMenuItemForElement<HslToRgbConverterElement>("HSL -> RGB", newMenu);
        }

        private void AddMatrixOpsItems(ToolStripMenuItem parentMenu)
        {
            ToolStripMenuItem newMenu = CreateMenu("Matrix Ops", parentMenu);
            AddMenuItemForElement<MatrixSlicerElement>("Matrix.GetSlice", newMenu);
            AddMenuItemForElement<ExpandEdgeMatrixFilterElement>("Expand Edge", newMenu);
        }

        private void AddPyramidProcessorItems(ToolStripMenuItem parentMenu)
        {
            ToolStripMenuItem newMenu = CreateMenu("Pyramid Processors", parentMenu);
            AddMenuItemForElement<ArithmeticMeanPyramidProcessor>("Arithmetic Mean Pyramid Processor", newMenu);
            AddMenuItemForElement<GeometricMeanPyramidProcessor>("Geometric Mean Pyramid Processor", newMenu);
            AddMenuItemForElement<MaxPyramidProcessor>("Max Pyramid Processor", newMenu);

        }

        private void AddMeasureItems(ToolStripMenuItem parentMenu)
        {
            ToolStripMenuItem newMenu = CreateMenu("Measure", parentMenu);
            AddMenuItemForElement<MssimMeasureElement>("Mssim", newMenu);
            AddMenuItemForElement<MseMeasureElement>("Mse", newMenu);
        }
        private void AddWindowCalculationItems(ToolStripMenuItem parentMenu)
        {
            ToolStripMenuItem newMenu = CreateMenu("Window Calculation", parentMenu);
            AddMenuItemForElement<AveragerElement>("Mean", newMenu);
            AddMenuItemForElement<VarianceCalculatorElement>("Variance", newMenu);
            AddMenuItemForElement<HistogramElement>("Histogram", newMenu);
            AddMenuItemForElement<CalculateIntervalMeasureElement>("Interval", newMenu);
        }
        private void AddWindowProcessorItems(ToolStripMenuItem parentMenu)
        {
            ToolStripMenuItem newMenu = CreateMenu("Window Processor", parentMenu);
            AddMenuItemForElement<AlphaTrimWindowProcessorElement>("Alpha Trim", newMenu);
            AddMenuItemForElement<ZetaTrimWindowProcessorElement>("Zeta Trim", newMenu);
        }

        private void AddZirconiaItems(ToolStripMenuItem parentMenu)
        {
            ToolStripMenuItem zirconiaMenu = CreateSectionMenu("Zirconia");

            AddMenuItemForElement<CSharpCompilerElement>("C# Compiler", zirconiaMenu);
            AddMenuItemForElement<SaveAssemblyElement>("Save Assembly", zirconiaMenu);
            AddMenuItemForElement<MethodInvokeElement>("Method Invoke", zirconiaMenu);
            AddMenuItemForElement<ConstructorInvokeElement>("Constructor", zirconiaMenu);
        }


        //void AddConverterItem_Click(object sender, EventArgs e)
        //{
        //    ConverterTypeSelectionForm form = new ConverterTypeSelectionForm();
        //    if (form.ShowDialog(this) == DialogResult.OK)
        //    {
        //        ConverterElementBase elem = ConverterElementBase.CreateConverter(form.InputType, form.OutputType);
        //        elem.Location = LastRightClickInDocument;
        //        AddElement(elem);
        //    }
        //}

        void ExecuteItem_Click(object sender, EventArgs e)
        {
            try
            {
                AmethystElement[] elements = Entities.Extract<AmethystElement>();

                _executionEngine.Execute(elements, _valueCache);

                StringBuilder sb = new StringBuilder();
                foreach (AmethystElement elem in elements)
                {
                    sb.AppendLine(elem.Text);
                }
                MessageBox.Show(this, "Success: \r\n" + sb.ToString());
            }
            catch (Exception ex)
            {
                ReportException(ex);
            }

            Invalidate();
        }

        void executionEngine_OnElementExecuted(object sender, AmethystElementEventArgs e)
        {
            InvalidateRectFromEntity(e.Element);
            Refresh();
        }

        void ExecuteAsyncItem_Click(object sender, EventArgs e)
        {
            ExecuteAsync();
        }

        protected override void UpdateContextMenuItems()
        {
            _deleteItem.Enabled = (Selection.Count > 0);
            _connectItem.Enabled = (_connectionSourceTerminal != null);
            _disconnectItem.Enabled = (_disconnectionCandidate != null && _disconnectionCandidate.Path != null);
        }

        //protected void AddMenuItemForFilter<T>(string text, ToolStripMenuItem menu)
        //    where T : MatrixFilter
        //{

        //}

        protected new void AddMenuItemForElement<T>(ToolStripItem item, ToolStripMenuItem menu)
            where T : AmethystElement, new()
        {
            base.AddMenuItemForElement<T>(item, menu);
        }

        public ToolStripItem AddMenuItemForElement<T>(string text, ToolStripMenuItem menu)
            where T : AmethystElement, new()
        {
            ToolStripMenuItem item = new ToolStripMenuItem(text);
            AddMenuItemForElement<T>(item, menu);
            return item;
        }

        protected new void AddElement_Click<T>(object sender, EventArgs e)
            where T : AmethystElement, new()
        {
            base.AddElement_Click<T>(sender, e);
        }

        //private void AddMenuItemForElement<T>(ToolStripItem item, ToolStripMenuItem menu)
        //    where T : AmethystElement, new()
        //{
        //    item.Click += new EventHandler(AddElement_Click<T>);
        //    menu.DropDownItems.Add(item);
        //}

        //private void AddElement_Click<T>(object sender, EventArgs e)
        //    where T : AmethystElement, new()
        //{
        //    T t = new T();
        //    t.Location = LastRightClickInDocument;
        //    AddElement(t);
        //}

        void ConnectItem_Click(object sender, EventArgs e)
        {
            _connecting = true;
        }

        void DeleteItem_Click2(object sender, EventArgs e)
        {
            try
            {
                AmethystElement[] elems = Selection.Extract<AmethystElement>();
                if (elems.Length > 0)
                {
                    foreach (Entity elem in elems)
                    {
                        DisconnectAndRemoveEntity(elem);
                    }
                }
            }
            catch (Exception ex)
            {
                ReportException(ex);
            }
        }

        void DisconnectItem_Click(object sender, EventArgs e)
        {
            if (_disconnectionCandidate != null)
            {
                InputTerminal terminalToDisconnect = _disconnectionCandidate;
                DisconnectInputTerminal(terminalToDisconnect);
            }
        }

        void SaveAsImageItem_Click(object sender, EventArgs e)
        {
            SaveContentsAsImagePrompt();
        }
    }
}

