using System;
using System.Windows;
using Prism.Events;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using PrismPractice.Event;

namespace PrismPractice.ViewModels
{
    public class Calculator : BindableBase, IDialogAware
    {
        #region プロパティ・フィールド

        private readonly IEventAggregator eventAggregator;

        /// <summary>ダイアログを閉じるときのイベント</summary>
        public event Action<IDialogResult> RequestClose;

        /// <summary>ダイアログのタイトル</summary>
        private readonly string title = "Dialog";
        public string Title { get => this.title; }

        #endregion

        #region コンストラクタ

        public Calculator(IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;

            this.eventAggregator.GetEvent<StringEvent>().Subscribe(this.OnEvent);
        }

        #endregion

        #region メソッド

        private void OnEvent(string args)
        {
            MessageBox.Show(args);
            this.eventAggregator.GetEvent<StringEvent>().Unsubscribe(this.OnEvent);
        }

        /// <summary>ダイアログを閉じることができるかを決める(通常はtrueでいい)</summary>
        public bool CanCloseDialog() => true;

        /// <summary>ダイアログを開いたときに実行されるイベント(パラメーターはここで受け取る)</summary>
        public void OnDialogOpened(IDialogParameters parameters)
        {
            // Sample1 = parameters.GetValue<string>("key1") ?? "error";
        }

        /// <summary>ダイアログを閉じたときに実行されるイベント</summary>
        public void OnDialogClosed()
        {
            RequestClose?.Invoke(new DialogResult());
        }

        #endregion

    }
}