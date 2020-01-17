﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HeBianGu.Application.TouchWindow
{
    /// <summary> "身高体重", "Loyout", "Bmi", "\xe618" </summary>
    class BmiLinkActionEntity : LinkActionEntity, IMeasure
    {
        public BmiLinkActionEntity()
        {
            this.DisplayName = "身高体重";
            this.Controller = "Loyout";
            this.Action = "Bmi";
            this.Logo = "\xe618";

        }

        private DataValueEntity _height = new DataValueEntity() { Name = "身高（cm）", Range = "" };
        /// <summary> 说明  </summary>
        public DataValueEntity Height
        {
            get { return _height; }
            set
            {
                _height = value;
                RaisePropertyChanged("Height");
            }
        }

        private DataValueEntity _weight = new DataValueEntity() { Name = " 体重（kg）" };
        /// <summary> 说明  </summary>
        public DataValueEntity Weight
        {
            get { return _weight; }
            set
            {
                _weight = value;
                RaisePropertyChanged("Weight");
            }
        }

        private DataValueEntity _bmi = new DataValueEntity() { Name = "BMI", Range = "参考范围：11.9 - 17.0" };
        /// <summary> 说明  </summary>
        public DataValueEntity Bmi
        {
            get { return _bmi; }
            set
            {
                _bmi = value;
                RaisePropertyChanged("Bmi");
            }
        }

        public override async Task<object> Start()
        {
            var result = await base.Start();

            if (result == null) return null;

            System.Windows.Application.Current.Dispatcher.Invoke(() =>
            {
                this.Height.SetValue("178.6", "#27DB20");
                this.Weight.SetValue("102.5", "#FCA814");
                this.Bmi.SetValue("25.3", "#FF2826");
            }); 

            return result; 
        }
    }
}
