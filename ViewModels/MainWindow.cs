using System;
using System.IO;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Windows;
using Prism.Events;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using PrismPractice.Event;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;

namespace PrismPractice.ViewModels
{
    public class MainWindow : BindableBase, IDisposable
    {
        #region タイトル

        //private string _title = "Prism Application";
        //public string Title
        //{
        //    get { return this._title; }
        //    set { this.SetProperty(ref this._title, value); }
        //}

        #endregion

        #region 定数

        private readonly string routePath = System.Environment.CurrentDirectory;
        private static readonly string backGroundPath = "C:\\Users\\user\\Desktop\\MyProject\\PrismPractice\\Resources\\RoadAndBike.png";

        #endregion

        #region フィールド・プロパティ

        private readonly IDialogService dialogService;

        private readonly IEventAggregator eventAggregator;

        private static CompositeDisposable Disposable { get; } = new CompositeDisposable();

        public ReactiveProperty<string> OK { get; set; } = new ReactiveProperty<string>("OK");
        public ReactiveProperty<string> BindingText { get; set; } = new ReactiveProperty<string>("初期値");
        public ReactiveProperty<string> TextBox { get; set; } = new ReactiveProperty<string>("初期値");
        public ReactiveProperty<string> BackGroundPath { get; set; } = new ReactiveProperty<string>(backGroundPath);
        public ReactiveProperty<string> DropFile { get; set; } = new ReactiveProperty<string>("ファイルをD&Dしてね！").AddTo(Disposable);
        public ReactiveProperty<string> TextBoxText { get; set; } = new ReactiveProperty<string>("ダブルクリックしてね！");
        public ReactiveProperty<string> TextBlockText { get; set; } = new ReactiveProperty<string>();
        public ReactiveProperty<Visibility> TextBoxVisibility { get; set; } = new ReactiveProperty<Visibility>(Visibility.Collapsed);
        public ReactiveProperty<Visibility> FontBorderTextVisibility { get; set; } = new ReactiveProperty<Visibility>(Visibility.Visible);

        public ReactiveCommand OpenCalculatorCommand { get; } = new ReactiveCommand();
        public ReactiveCommand AddItemControllCommand { get; } = new ReactiveCommand();
        public ReactiveCommand<DragEventArgs> FileDropCommand { get; } = new ReactiveCommand<DragEventArgs>().AddTo(Disposable);
        public ReactiveCommand DoubleClickCommand { get; } = new ReactiveCommand().AddTo(Disposable);
        public ReactiveCommand LostFocusEvent { get; } = new ReactiveCommand().AddTo(Disposable);
        // public ReactiveCommand LoadedEvent { get; } = new ReactiveCommand().AddTo(Disposable);

        public ReactiveCollection<ItemControll> ItemControll { get; } = new ReactiveCollection<ItemControll>();

        #endregion

        #region コンストラクタ

        public MainWindow(
            IEventAggregator eventAggregator,
            IDialogService dialogService)
        {
            this.eventAggregator = eventAggregator;
            this.dialogService = dialogService;

            this.OpenCalculatorCommand.Subscribe(this.OnOpenCalculatorClicked);
            this.AddItemControllCommand.Subscribe(this.OnAddItemControllClicked);
            this.FileDropCommand.Subscribe(this.OnFileDropEvent);
            this.DoubleClickCommand.Subscribe(this.OnDoubleClickEvent);
            this.LostFocusEvent.Subscribe(this.OnLostFocusEvent);
            // this.LoadedEvent.Subscribe(this.OnLoadedEvent);
        }

        #endregion

        #region メソッド

        private void OnOpenCalculatorClicked()
        {
            this.dialogService.ShowDialog("Calculator", new DialogParameters(), (results) =>
            {

            });
            // this.eventAggregator.GetEvent<StringEvent>().Publish("イベント届いたぜ！");
        }

        private void OnAddItemControllClicked()
        {
            this.ItemControll.Add(new ItemControll());
        }

        private void OnFileDropEvent(DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(DataFormats.FileDrop))
                return;

            var dropFiles = e.Data.GetData(DataFormats.FileDrop) as string[];

            if (dropFiles == null)
                return;

            if (File.Exists(dropFiles[0]))
            {
                this.DropFile.Value = dropFiles[0];
            }
            else
            {
                this.DropFile.Value = "ドロップされたものはファイルではありません";
            }
        }

        private void OnDoubleClickEvent()
        {
            this.TextBoxVisibility.Value = Visibility.Visible;
            this.FontBorderTextVisibility.Value = Visibility.Collapsed;
            this.TextBlockText.Value = this.TextBoxText.Value;
        }

        private void OnLostFocusEvent()
        {
            this.TextBoxVisibility.Value = Visibility.Collapsed;
            this.FontBorderTextVisibility.Value = Visibility.Visible;
        }

        //private void OnLoadedEvent()
        //{
        //    this.TextBlockText.Value = this.TextBoxText.Value;
        //    this.TextBoxVisibility.Value = Visibility.Collapsed;
        //    this.FontBorderTextVisibility.Value = Visibility.Visible;
        //}

        public void Dispose()
        {
            Disposable.Dispose();
        }

        #endregion
    }
}
