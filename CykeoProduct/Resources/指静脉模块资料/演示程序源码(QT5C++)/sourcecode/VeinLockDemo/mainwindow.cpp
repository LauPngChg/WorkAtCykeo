#include "mainwindow.h"
#include "ui_mainwindow.h"
MainWindow::MainWindow(QWidget *parent) : QMainWindow(parent), ui(new Ui::MainWindow)
{
    QString strTemp;
    ui->setupUi(this);

    my_serialport= new QSerialPort();
    SP_refresh();
    for(int i=255;i>=0;i--)
    {
        strTemp = QString("%1").arg(i);
        ui->comboBox_Devid->addItem(strTemp);
    }
}

MainWindow::~MainWindow()
{
    my_serialport->close();
    delete ui;
}

void MainWindow::DisplayPage(int PageID)
{
    switch(PageID)
    {
    case NULLPage:
        textbuffer="";
        break;
    case MainMenuPages:
        textbuffer="1.验证手指菜单\n2.注册手指菜单\n3.删除手指菜单\n4.手指信息菜单\n5.系统参数菜单";
        break;
    case VerifyPages:
        textbuffer="1.手指1:N验证\n2.手指1:G验证\n3.手指1:1验证";
        break;
    case Verify_OneVsN_ExecuPage:
        textbuffer="开始手指1:N验证！按“ESC”可退出验证。\n";
        break;
    case Verify_OneVsG_GetGIDPage:
        textbuffer="开始手指1:G验证前，请先输入GID，再按确认键，范围为0~255。\nGID:";
        GID="";
        break;
    case Verify_OneVsG_ExecuPage:
        textbuffer="开始手指1:G验证！按“ESC”可退出验证。\n";
        break;
    case Verify_OneVsOne_GetFIDPage:
        textbuffer="开始手指1:1验证前，请先输入FID，再按确认键，范围为0~65535。\nFID:";
        FID="";
        break;
    case Verify_OneVsOne_ExecuPage:
        textbuffer="开始手指1:1验证！按“ESC”可退出验证。\n";
        break;

    case RegisterPages:
        textbuffer="1.自动注册手指\n2.手动注册手指";
        break;
    case RegisterAutoPage_ExecuPage:
        textbuffer="开始采集手指模板，请放手指！按“ESC”可结束本次注册。\n";
        break;
    case RegisterPage_GetREGCntPage:
        textbuffer="请先输入手指注册次数，再按确认键，范围为3~10。\nCnt:";
        REGCnt="";
        break;
    case RegisterPage_GetFIDPage:
        textbuffer="请先输入FID，再按确认键，范围为0~65535。\nFID:";
        FID="";
        break;
    case RegisterPage_GetGIDPage:
        textbuffer="再先输入GID，再按确认键，范围为0~255。\nGID:";
        GID="";
        break;
    case RegisterPage_ExecuPage:
        textbuffer="开始采集手指模板，请放手指！按“ESC”可结束本次注册。\n";
        break;
    case RegisterEndPage_GetChoPages:
        textbuffer="采集完成，请选择如下处理：\n1.取消本次注册\n2.采集静脉特征写入设备\n3.采集静脉特征回传上位机！（上传时间长，请耐心等待。）\n";
        break;
    case RegisterEndPage_ExecuPage:
        textbuffer="开始执行注册操作！\n";
        break;

    case DeleteTmpPages:
        textbuffer="1.删除单个手指\n2.删除所有手指";
        break;
    case DeleteOneTmp_GetFIDPage:
        textbuffer="输入要删除FID，确认后请按ENT键！\nID:";
        FID="";
        break;
    case DeleteOneTmp_ExecuPage:
        textbuffer="FID："+FID+" 开始删除！\n";
        break;
    case DeleteAllTmp_EnsurePage:
        textbuffer="删除所有手指模板?请按ENT键再一次确认！";
        break;
    case DeleteAllTmp_ExecuPage:
        textbuffer="开始删除所有手指模板，请耐心等待！\n";
        break;

    case FIDDataPages:
        textbuffer="1.上传所有手指FID和GID\n2.通过FID获取手指信息\n3.通过FID获取静脉特征\n4.通过FID获取手指信息头和静脉特征\n5.获取当前静脉特征\n6.下载单个FID的手指信息和静脉特征";
        break;
    case GetALLID_ExecuPage:
        textbuffer="开始获取所有FID和GID！\n";
        break;
    case GetFIDInfo_GetFIDPage:
        textbuffer="输入要获取手指的FID，确认后请按ENT键！\nID:";
        FID="";
        break;
    case GetFIDInfo_ExecuPage:
        textbuffer="开始获取指定手指信息！\n";
        break;
    case GetTemplate_GetFIDPage:
        textbuffer="输入要获取模板的FID，确认后请按ENT键！\nID:";
        FID="";
        break;
    case GetTemplate_GetFingnumPage:
        textbuffer="输入该FID的指定模板的序号，范围1~10，确认后请按ENT键！\nID:";
        FinNo="";
        break;
    case GetTemplate_ExecuPage:
        textbuffer="开始获取指定模板";
        break;
    case GetFIDAllData_GetFIDPage:
        textbuffer="输入要获取手指的FID，确认后请按ENT键！\nID:";
        FID="";
        break;
    case GetFIDAllData_ExecuPage:
        textbuffer="开始获取指定FID手指信息头和模板！上传时间长，请耐心等待。\n";
        break;
    case GetCurrentTmp_ExecuPage:
        textbuffer="开始获取当前模板！\n";
        break;
    case DownloadFIDTmp_GetFIDPage:
        textbuffer="输入要下载手指的FID，确认后请按ENT键！\nID:";
        FID="";
        break;
    case DownloadFIDTmp_ExecuPage:
        textbuffer="开始下载手指信息头和模板！下载时间长，请耐心等待。\n";
        break;

    case SystemParaPages:
        textbuffer="1.获取软件版本号\n2.获取已注册手指数\n3.检查手指状态\n4.获取设备序列号\n5.设置设备波特率\n6.设置设备编号";
        break;
    case GetSoftwareVer_ExecuPage:
        textbuffer="开始获取设备ID和软件版本号";
        break;
    case GetRegisterFig_ExecuPage:
        textbuffer="开始获取已注册手指数";
        break;
    case GetFingerstate_ExecuPage:
        textbuffer="开始检查手指状态";
        break;
    case GetDeviceSer_ExecuPage:
        textbuffer="开始获取设备序列号";
        break;
    case SetBaudrate_GetBaudpage:
        textbuffer="请输入要设置的波特率，确认后请按ENT键！支持的波特率有9600bps,19200bps,57600bps,115200bps\nBPS:";
        devBuad="";
        break;
    case SetBaudrate_ExecuPage:
        textbuffer="开始设置设备波特率"+devBuad;
        break;
    case SetDevid_GetDevid:
        textbuffer="请输入要设置的设备号，确认后请按ENT键！通信地址范围为0~255\n通信地址:";
        devid="";
        break;
    case SetDevid_ExecuPage:
        textbuffer="开始设置通信地址"+devid;
        break;
    default:
        break;
    }
    ui->textEdit->setPlainText(textbuffer);//显示界面
    CurrentPageID = PageID;//当前页面ID切换；
    QCoreApplication::processEvents(QEventLoop::ExcludeUserInputEvents);
}

unsigned char MainWindow::Check_Xor(unsigned char *data,unsigned int len)
{
  unsigned int i;
  unsigned char chk;
  chk = *data;
  for(i=1;i<len;i++)
  {
    chk ^= *(data+i);
  }
  return chk;
}

unsigned int MainWindow::GetRand(unsigned int MIN,unsigned int MAX)
{
   int max;
   unsigned int randnum;
   max = RAND_MAX;
   qsrand(QTime(0,0,0).secsTo(QTime::currentTime()));
   randnum = ((MAX-MIN)*qrand()/max) +MIN;
   return randnum;
}

//串口刷新
void MainWindow::SP_refresh()
{
    ui->comboBox->clear();
    foreach (const QSerialPortInfo &info, QSerialPortInfo::availablePorts())
    {
        qDebug() << "Name        : " << info.portName();
        qDebug() << "Description : " << info.description();
        qDebug() << "Manufacturer: " << info.manufacturer();

        // Example use QSerialPort
        QSerialPort serial;
        serial.setPort(info);

        if (serial.open(QIODevice::ReadWrite))
        {
            ui->comboBox->addItem(info.portName());
            ui->textEdit_debug->append("检测到串口"+info.portName());
            serial.close();
        }
    }
    DisplayPage(NULLPage);//显示界面为空
}

bool MainWindow::CheckCOMisOpen()
{
    if(!my_serialport->isOpen())
    {
        ui->textEdit_debug->append("串口未打开！");
        return false;
    }
    return true;
}

void MainWindow::on_pBn_refresh_clicked()
{
    my_serialport->close();//刷新前把可能打开的串口关闭
    SP_refresh();
    ui->textEdit_debug->append("刷新成功后请重新“打开串口”");
}

void MainWindow::on_pBn_comopen_clicked()
{
    int error;
    my_serialport->close();
    qDebug()<<ui->comboBox->currentText();
    my_serialport->setPortName(ui->comboBox->currentText());

    if(! my_serialport->open(QIODevice::ReadWrite))
    {
        error = my_serialport->error();
        qDebug()<<"open com failed,error is "<<error;
        ui->textEdit_debug->append("串口"+ui->comboBox->currentText()+"打开失败");
        return;
    }

    QString combps;
    combps=ui->comboBox_combps->currentText();//获取波特率
    qDebug() << combps;

    my_serialport->setBaudRate(combps.toInt(),QSerialPort::AllDirections);
    my_serialport->setDataBits(QSerialPort::Data8);
    my_serialport->setParity(QSerialPort::NoParity);
    my_serialport->setStopBits(QSerialPort::OneStop);
    my_serialport->setFlowControl(QSerialPort::NoFlowControl);

    ui->textEdit_debug->append("串口"+ui->comboBox->currentText()+"打开成功，波特率为"+combps);
    DisplayPage(MainMenuPages);//初始化显示主页面。
}

void MainWindow::on_Btn_Digital_1_clicked()
{
    if(CheckCOMisOpen()==false) return;

    DigitalKeysOperation(1);
}

void MainWindow::on_Btn_Digital_2_clicked()
{
    if(CheckCOMisOpen()==false) return;
    DigitalKeysOperation(2);
}

void MainWindow::on_Btn_Digital_3_clicked()
{
    if(CheckCOMisOpen()==false) return;
    DigitalKeysOperation(3);
}

void MainWindow::on_Btn_Digital_4_clicked()
{
    if(CheckCOMisOpen()==false) return;
    DigitalKeysOperation(4);
}

void MainWindow::on_Btn_Digital_5_clicked()
{
    if(CheckCOMisOpen()==false) return;
    DigitalKeysOperation(5);
}

void MainWindow::on_Btn_Digital_6_clicked()
{
    if(CheckCOMisOpen()==false) return;
    DigitalKeysOperation(6);
}

void MainWindow::on_Btn_Digital_7_clicked()
{
    if(CheckCOMisOpen()==false) return;
    DigitalKeysOperation(7);
}

void MainWindow::on_Btn_Digital_8_clicked()
{
    if(CheckCOMisOpen()==false) return;
    DigitalKeysOperation(8);
}

void MainWindow::on_Btn_Digital_9_clicked()
{
    if(CheckCOMisOpen()==false) return;
    DigitalKeysOperation(9);
}

void MainWindow::on_Btn_Digital_0_clicked()
{
    if(CheckCOMisOpen()==false) return;
    DigitalKeysOperation(0);
}

void MainWindow::on_Btn_Esc_clicked()
{
    uint LastPageID;
    if(CheckCOMisOpen()==false) return;
    if((CurrentPageID==RegisterAutoPage_ExecuPage)||(CurrentPageID==RegisterPage_ExecuPage))//按ESC退出注册
    {
        Registerend(1);//发送结束命令。

        QCoreApplication::processEvents(QEventLoop::ExcludeUserInputEvents);
        QThread::msleep(1000);
        DisplayPage(MainMenuPages);
    }
    //按ESC退出三类验证
    else if((CurrentPageID==Verify_OneVsN_ExecuPage)||(CurrentPageID==Verify_OneVsG_ExecuPage)||(CurrentPageID==Verify_OneVsOne_ExecuPage))
    {
        QCoreApplication::processEvents(QEventLoop::ExcludeUserInputEvents);
        QThread::msleep(1000);
        DisplayPage(MainMenuPages);
    }
    //按ESC回到上一界面
    else if(CurrentPageID<10000)
    {
        LastPageID=CurrentPageID/10;
        DisplayPage(LastPageID);
    }
    else
    {
        ui->textEdit_debug->append("无效按键");
    }
}

void MainWindow::on_Btn_Ent_clicked()
{
    if(CheckCOMisOpen()==false) return;
    switch(CurrentPageID)
    {
    case Verify_OneVsG_GetGIDPage:
        if(255<GID.toInt())
        {
            ui->textEdit->setPlainText(textbuffer);
            ui->textEdit->append("GID应小于255，请重新输入");
            qDebug()<<"the GID is less 255";
            GID="";
            return;
        }
        DisplayPage(Verify_OneVsG_ExecuPage);
        //进行多次检测手指操作。
        if(FingerDetectStateChange(FigerisTakeOff))//检测到手指放上
        {
            Verifytemplate(CMD_ONE_VS_G);//执行验证模板操作
        }
        QCoreApplication::processEvents(QEventLoop::ExcludeUserInputEvents);
        QThread::msleep(1000);
        DisplayPage(MainMenuPages);
        break;
    case Verify_OneVsOne_GetFIDPage:
        if(65535<FID.toInt())
        {
            ui->textEdit->setPlainText(textbuffer);
            ui->textEdit->append("FID小于65535，请重新输入");
            qDebug()<<"the FID is less 65535";
            FID="";
            return;
        }
        DisplayPage(Verify_OneVsOne_ExecuPage);
        //进行多次检测手指操作。
        if(FingerDetectStateChange(FigerisTakeOff))//检测到手指放上
        {
            Verifytemplate(CMD_ONE_VS_ONE);//执行验证模板操作
        }
        QCoreApplication::processEvents(QEventLoop::ExcludeUserInputEvents);
        QThread::msleep(1000);
        DisplayPage(MainMenuPages);
        break;
    case RegisterPage_GetREGCntPage:
        if((10<REGCnt.toInt())||(3>REGCnt.toInt()))
        {
            ui->textEdit->setPlainText(textbuffer);
            ui->textEdit->append("注册次数范围为3~10，请重新输入");
            qDebug()<<"the FID is less 65535";
            REGCnt="";
            return;
        }
        DisplayPage(RegisterPage_GetFIDPage);
        break;
    case RegisterPage_GetFIDPage:
        if(65535<FID.toInt())
        {
            ui->textEdit->setPlainText(textbuffer);
            ui->textEdit->append("FID小于65535，请重新输入");
            qDebug()<<"the FID is less 65535";
            FID="";
            return;
        }
        DisplayPage(RegisterPage_GetGIDPage);
        break;
    case RegisterPage_GetGIDPage:
        if(255<GID.toInt())
        {
            ui->textEdit->setPlainText(textbuffer);
            ui->textEdit->append("GID应小于255，请重新输入");
            qDebug()<<"the GID is less 255";
            GID="";
            return;
        }
        DisplayPage(RegisterPage_ExecuPage);

        RegisterManyTimes();

        if(flag_register_success_cnt < REGCnt.toInt())//流程结束，返回主界面
        {
            QCoreApplication::processEvents(QEventLoop::ExcludeUserInputEvents);
            QThread::msleep(1000);
            DisplayPage(MainMenuPages);
            break;
        }
        DisplayPage(RegisterEndPage_GetChoPages);
        break;
    case DeleteOneTmp_GetFIDPage: //ID输入成功
        if(65535<FID.toInt())
        {
            ui->textEdit->setPlainText(textbuffer);
            ui->textEdit->append("FID小于65535，请重新输入");
            qDebug()<<"the FID is less 65535";
            FID="";
            return;
        }
        DisplayPage(DeleteOneTmp_ExecuPage);
        DeleteOnetemplate();//删除指定ID手指模板

        QCoreApplication::processEvents(QEventLoop::ExcludeUserInputEvents);
        QThread::msleep(1000);
        DisplayPage(MainMenuPages);
        break;

    case DeleteAllTmp_EnsurePage:
        DisplayPage(DeleteAllTmp_ExecuPage);
        DeleteAlltemplate();

        QCoreApplication::processEvents(QEventLoop::ExcludeUserInputEvents);
        QThread::msleep(1000);
        DisplayPage(MainMenuPages);
        break;

    case GetFIDInfo_GetFIDPage:
        if(65535<FID.toInt())
        {
            ui->textEdit->setPlainText(textbuffer);
            ui->textEdit->append("FID小于65535，请重新输入");
            qDebug()<<"the FID is less 65535";
            FID="";
            return;
        }
        DisplayPage(GetFIDInfo_ExecuPage);
        GetFIDInfo();//获取指定ID手指信息头

        QCoreApplication::processEvents(QEventLoop::ExcludeUserInputEvents);
        QThread::msleep(1000);
        DisplayPage(MainMenuPages);
        break;

    case GetTemplate_GetFIDPage:
        if(65535<FID.toInt())
        {
            ui->textEdit->setPlainText(textbuffer);
            ui->textEdit->append("FID小于65535，请重新输入");
            qDebug()<<"the FID is less 65535";
            FID="";
            return;
        }
        DisplayPage(GetTemplate_GetFingnumPage);
        break;
    case GetTemplate_GetFingnumPage:
        if(10<FinNo.toInt()||1>FinNo.toInt())
        {
            ui->textEdit->setPlainText(textbuffer);
            ui->textEdit->append("每个手指可读模板序号为1~10，请重新输入");
            qDebug()<<"the FinNo is less 10";
            FinNo="";
            return;
        }
        DisplayPage(GetTemplate_ExecuPage);
        GetTemplate();//获取指定ID手指模板

        QCoreApplication::processEvents(QEventLoop::ExcludeUserInputEvents);
        QThread::msleep(1000);
        DisplayPage(MainMenuPages);
        break;

    case GetFIDAllData_GetFIDPage:
        if(65535<FID.toInt())
        {
            ui->textEdit->setPlainText(textbuffer);
            ui->textEdit->append("FID小于65535，请重新输入");
            qDebug()<<"the FID is less 65535";
            FID="";
            return;
        }
        DisplayPage(GetFIDAllData_ExecuPage);
        GetFIDAllData();//获取手指和所有模板信息

        QCoreApplication::processEvents(QEventLoop::ExcludeUserInputEvents);
        QThread::msleep(1000);
        DisplayPage(MainMenuPages);
        break;

    case DownloadFIDTmp_GetFIDPage:
        if(65535<FID.toInt())
        {
            ui->textEdit->setPlainText(textbuffer);
            ui->textEdit->append("FID小于65535，请重新输入");
            qDebug()<<"the FID is less 65535";
            FID="";
            return;
        }
        DisplayPage(DownloadFIDTmp_ExecuPage);

        DownloadFIDTmp();//获取指定ID手指信息头

        QCoreApplication::processEvents(QEventLoop::ExcludeUserInputEvents);
        QThread::msleep(1000);
        DisplayPage(MainMenuPages);
        break;

    case SetBaudrate_GetBaudpage:
        DisplayPage(SetBaudrate_ExecuPage);
        SetBuadrate();

        QCoreApplication::processEvents(QEventLoop::ExcludeUserInputEvents);
        QThread::msleep(1000);
        DisplayPage(MainMenuPages);
        break;

    case SetDevid_GetDevid:
        if(255<devid.toInt())
        {
            ui->textEdit->setPlainText(textbuffer);
            ui->textEdit->append("设备编码应小于255，请重新输入");
            qDebug()<<"the devid is less 255";
            devid="";
            return;
        }
        DisplayPage(SetDevid_ExecuPage);
        SetDevid();

        QCoreApplication::processEvents(QEventLoop::ExcludeUserInputEvents);
        QThread::msleep(1000);
        DisplayPage(MainMenuPages);
        break;
    default:
        ui->textEdit_debug->append("无效按键");
        break;
    }
}

void MainWindow::on_pB_cleartextdebug_clicked()
{
    ui->textEdit_debug->clear();
}

void MainWindow::on_pB_cleartextRWdata_clicked()
{
    ui->textEdit_RWdata->clear();
}



bool MainWindow::ReadbuffDisplay(uint waitms)
{
    QTime qtimeobj;
    QString timestr;
    unsigned int strlen;
    if (my_serialport->waitForBytesWritten(8000))//下载10个模板时准备好数据用时比较多
    {
        qDebug() <<"send data success";

        qtimeobj = QTime::currentTime();
        timestr = qtimeobj.toString("h:m:s ap");
        ui->textEdit_RWdata->append("Data Out "+timestr+"\n"+tempDataHex);//16进制转换成ASCII用于显示。

        //进入等待接收数据前先处理完界面显示操作。
        QCoreApplication::processEvents(QEventLoop::ExcludeUserInputEvents);

        requestData= "";
        if(my_serialport->waitForReadyRead(waitms))
        {
            requestData = this->my_serialport->readAll();
            while(1)
            {
                if(my_serialport->waitForReadyRead(50))
                {
                    requestData += this->my_serialport->readAll();
                }
                else
                {
                    break;
                }
            }

            tempDataHex = MainWindow::ByteArrayToHexStr(requestData);

            qtimeobj = QTime::currentTime();
            timestr = qtimeobj.toString("h:m:s ap");
            ui->textEdit_RWdata->append("Data In  "+timestr+"\n"+tempDataHex);//16进制转换成ASCII用于显示。
            //进入等待接收数据前先处理完界面显示操作。
            QCoreApplication::processEvents(QEventLoop::ExcludeUserInputEvents);
            qDebug() <<"receive OK";

            unsigned char *data = (unsigned char *)(requestData.data());
            strlen = requestData.length();
            if(0x0d == data[strlen-1])//确定最后一位发送的是结束符
            {
                if(data[6] == Check_Xor(data,6))
                {
                    if(0x08 == strlen)
                    {
                        return true;
                    }
                    else if(data[strlen-2] == Check_Xor(&data[8],data[3]+data[4]*256+3))
                    {
                        return true;
                    }
                }
            }
            ui->textEdit_debug->append("校验失败");
            return false;
        }
        else
        {
            ui->textEdit_debug->append("数据接收失败");
            return false;
        }
    }
    else
    {
        ui->textEdit_debug->append("数据发送失败");
        return false;
    }
}

void MainWindow::DigitalKeysOperation(int keysnum)
{
    switch(CurrentPageID)
    {
    case MainMenuPages:
    {
        switch(keysnum)
        {
        case 1:
            DisplayPage(VerifyPages);
            break;
        case 2:
            DisplayPage(RegisterPages);
            break;
        case 3:
            DisplayPage(DeleteTmpPages);
            break;
        case 4:
            DisplayPage(FIDDataPages);
            break;
        case 5:
            DisplayPage(SystemParaPages);
            break;
        default:
            DisplayPage(MainMenuPages);
            ui->textEdit_debug->append("无效按键");
            break;
        }
        break;
    }

    case VerifyPages:
    {
        switch(keysnum)
        {
        case 1:
            DisplayPage(Verify_OneVsN_ExecuPage);
            //进行多次检测手指操作。
            if(FingerDetectStateChange(FigerisTakeOff))//检测到手指放上
            {
                Verifytemplate(CMD_ONE_VS_N);//执行验证模板操作
            }
            QCoreApplication::processEvents(QEventLoop::ExcludeUserInputEvents);
            QThread::msleep(1000);
            DisplayPage(MainMenuPages);
            break;
        case 2:
            DisplayPage(Verify_OneVsG_GetGIDPage);
            break;
        case 3:
            DisplayPage(Verify_OneVsOne_GetFIDPage);
            break;
        default:
            DisplayPage(VerifyPages);
            ui->textEdit_debug->append("无效按键");
            break;
        }
        break;
    }

    case RegisterPages:
    {
        switch(keysnum)
        {
        case 1:
            DisplayPage(RegisterAutoPage_ExecuPage);
            RegistAuto();

            if(flag_register_success_cnt < REGCnt.toInt())//流程结束，返回主界面
            {
                QCoreApplication::processEvents(QEventLoop::ExcludeUserInputEvents);
                QThread::msleep(1000);
                DisplayPage(MainMenuPages);
                break;
            }
            DisplayPage(RegisterEndPage_GetChoPages);

            break;
        case 2:
            DisplayPage(RegisterPage_GetREGCntPage);
            break;
        default:
            DisplayPage(RegisterPages);
            ui->textEdit_debug->append("无效按键");
            break;
        }
        break;
    }

    case DeleteTmpPages:
    {
        switch(keysnum)
        {
        case 1:
            DisplayPage(DeleteOneTmp_GetFIDPage);
            break;
        case 2:
            DisplayPage(DeleteAllTmp_EnsurePage);
            break;
        default:
            DisplayPage(DeleteTmpPages);
            ui->textEdit_debug->append("无效按键");
            break;
        }
        break;
    }

    case FIDDataPages:
    {
        switch(keysnum)
        {
        case 1:
            DisplayPage(GetALLID_ExecuPage);
            GetALLID();
            QCoreApplication::processEvents(QEventLoop::ExcludeUserInputEvents);
            QThread::msleep(1000);
            DisplayPage(MainMenuPages);
            break;
        case 2:
            DisplayPage(GetFIDInfo_GetFIDPage);
            break;
        case 3:
            DisplayPage(GetTemplate_GetFIDPage);
            break;
        case 4:
            DisplayPage(GetFIDAllData_GetFIDPage);
            break;
        case 5:
            DisplayPage(GetCurrentTmp_ExecuPage);
            GetCurrentTmp();//获取当前手指模板

            QCoreApplication::processEvents(QEventLoop::ExcludeUserInputEvents);
            QThread::msleep(1000);
            DisplayPage(MainMenuPages);
            break;
        case 6:
            DisplayPage(DownloadFIDTmp_GetFIDPage);
            break;
        default:
            DisplayPage(FIDDataPages);
            ui->textEdit_debug->append("无效按键");
            break;
        }
        break;
    }

    case SystemParaPages:
    {
        switch(keysnum)
        {
        case 1:
            DisplayPage(GetSoftwareVer_ExecuPage);
            GetSoftwareVer();

            QCoreApplication::processEvents(QEventLoop::ExcludeUserInputEvents);
            QThread::msleep(1000);
            DisplayPage(MainMenuPages);
            break;
        case 2:
            DisplayPage(GetRegisterFig_ExecuPage);
            GetRegisterFig();

            QCoreApplication::processEvents(QEventLoop::ExcludeUserInputEvents);
            QThread::msleep(1000);
            DisplayPage(MainMenuPages);
            break;
        case 3:
            DisplayPage(GetFingerstate_ExecuPage);
            GetFingerstate();

            QCoreApplication::processEvents(QEventLoop::ExcludeUserInputEvents);
            QThread::msleep(1000);
            DisplayPage(MainMenuPages);
            break;
        case 4:
            DisplayPage(GetDeviceSer_ExecuPage);
            GetDeviceSer();

            QCoreApplication::processEvents(QEventLoop::ExcludeUserInputEvents);
            QThread::msleep(1000);
            DisplayPage(MainMenuPages);
            break;
        case 5:
            DisplayPage(SetBaudrate_GetBaudpage);
            break;
        case 6:
            DisplayPage(SetDevid_GetDevid);
            break;
        default:
            DisplayPage(SystemParaPages);
            ui->textEdit_debug->append("无效按键");
            break;
        }
        break;
    }

    case RegisterEndPage_GetChoPages:
    {
        DisplayPage(RegisterEndPage_ExecuPage);
        if((keysnum>0)&&(keysnum<4))
        {
            Registerend((char)keysnum);//发送结束命令。

            QCoreApplication::processEvents(QEventLoop::ExcludeUserInputEvents);
            QThread::msleep(1000);
            DisplayPage(MainMenuPages);
        }
        else
        {
            DisplayPage(RegisterEndPage_GetChoPages);
            ui->textEdit_debug->append("无效按键");
        }
        break;
    }
    case DeleteOneTmp_GetFIDPage:
    case GetTemplate_GetFIDPage:
    case GetFIDAllData_GetFIDPage:
    case GetFIDInfo_GetFIDPage:
    case DownloadFIDTmp_GetFIDPage:
    case Verify_OneVsOne_GetFIDPage:
    case RegisterPage_GetFIDPage:
        FID.append(QString::number(keysnum,10));
        ui->textEdit->setPlainText(textbuffer+FID);
        break;
    case Verify_OneVsG_GetGIDPage:
    case RegisterPage_GetGIDPage:
        GID.append(QString::number(keysnum,10));
        ui->textEdit->setPlainText(textbuffer+GID);
        break;
    case GetTemplate_GetFingnumPage:
        FinNo.append(QString::number(keysnum,10));
        ui->textEdit->setPlainText(textbuffer+FinNo);
        break;
    case RegisterPage_GetREGCntPage:
        REGCnt.append(QString::number(keysnum,10));
        ui->textEdit->setPlainText(textbuffer+REGCnt);
        break;
    case SetBaudrate_GetBaudpage:
        devBuad.append(QString::number(keysnum,10));
        ui->textEdit->setPlainText(textbuffer+devBuad);
        break;
    case SetDevid_GetDevid:
        devid.append(QString::number(keysnum,10));
        ui->textEdit->setPlainText(textbuffer+devid);
        break;
    default:
        ui->textEdit_debug->append("无效按键");
        break;
    }
}

int MainWindow::FingerDetect()
{
    QByteArray TxData;
    TxData[0] = ASCII_XON;
    TxData[1] = CMD_CHK_FINGER;
    TxData[2] = ui->comboBox_Devid->currentText().toInt();
    TxData[3] = 0x00;
    TxData[4] = 0x00;
    TxData[5] = 0x00;
    TxData[6] = Check_Xor((unsigned char *)(TxData.data()),6);
    TxData[7] = ASCII_XOFF;

    my_serialport->clear(QSerialPort::AllDirections);
    my_serialport->write(TxData);

    tempDataHex = MainWindow::ByteArrayToHexStr(TxData);//16进制转换成ASCII用于显示。
    if(ReadbuffDisplay(2000))
    {
        switch((unsigned char)requestData[5])
        {
        case 0x00:
            return 0;
            break;
        case 0x01:
            return 1;
            break;
        default:
            return -1;
            break;
        }
    }
    else
    {
        return -1;
    }
}

bool MainWindow::FingerDetectStateChange(int state)
{
    int i=0,detectstate;

    while(1)
    {
        detectstate=FingerDetect();
        if( -1 == detectstate) return false;//如果通信错误，直接退出。
        else if( state == detectstate)
        {
            if(i<40)//循环检测40次
            {
                QCoreApplication::processEvents();

                if(CurrentPageID == MainMenuPages)
                {
                    return false;
                }

                textbuffer+="*";
                ui->textEdit->setPlainText(textbuffer);
                QThread::msleep(50);
                i++;
            }
            else
            {
                switch (state)
                {
                case 0:
                    textbuffer="手指未移开超时，退出界面";
                    break;
                case 1:
                    textbuffer="手指未放置超时，退出界面";
                    break;
                default:
                    break;
                }
                ui->textEdit->setPlainText(textbuffer);
                ui->textEdit_debug->append(textbuffer);
                return false;
            }
        }
        else
        {
            return true;
        }
    }
}

void MainWindow::Verifytemplate(char cmd)
{
    QByteArray TxData;
    int FIDnum;
    int GIDnum;
    TxData[0] = ASCII_XON;
    TxData[1] = cmd;
    TxData[2] = ui->comboBox_Devid->currentText().toInt();
    TxData[3] = 0x00;
    TxData[4] = 0x00;
    TxData[5] = 0x00;

    if(cmd == CMD_ONE_VS_G)
    {
        GIDnum = GID.toInt();
        TxData[5] = GIDnum;
    }
    if(cmd == CMD_ONE_VS_ONE)
    {
        FIDnum = FID.toInt();
        TxData[3] = FIDnum%256;
        TxData[4] = FIDnum/256;
    }

    TxData[6] = Check_Xor((unsigned char *)(TxData.data()),6);
    TxData[7] = ASCII_XOFF;

    my_serialport->clear(QSerialPort::AllDirections);
    my_serialport->write(TxData);

    tempDataHex = MainWindow::ByteArrayToHexStr(TxData);//16进制转换成ASCII用于显示。
    if(ReadbuffDisplay(4000))//等待验证命令返回超时错误
    {
        switch((unsigned char)requestData[5])
        {
        case ERR_SUCCESS:
        {
            QString temp="";
            int tempint;
            tempint=(unsigned char)requestData[3]+(unsigned char)requestData[4]*256;
            temp = QString::number(tempint,10);
            textbuffer="匹配成功！FID为："+temp;
            ui->textEdit->setPlainText(textbuffer);
            ui->textEdit_debug->append(textbuffer);
            return;
            break;
        }
        case ERR_FALT:
            textbuffer="匹配失败！";
            break;
        case ERR_GROUPID_NULL:
            textbuffer="匹配失败！无此GID";
            break;
        case ERR_NO_FINGER:
            textbuffer="匹配失败！未检测到手指！";
            break;
        default:
            textbuffer="匹配失败！";
            break;
        }
        ui->textEdit->setPlainText(textbuffer);
        ui->textEdit_debug->append(textbuffer);
    }
}

void MainWindow::RegistAuto()
{
    unsigned int RandomFid;
    REGCnt = "3";
    GID = "1";

    RandomFid = GetRand(0,65535);
    FID = QString::number(RandomFid,10);

    ui->textEdit_debug->append("分配FID:"+FID+"，默认GID：1，模板数3。");

    RegisterManyTimes();
}

void MainWindow::RegisterManyTimes()
{
    flag_register_success_cnt=0;
    if(false == Registerbegin())//每次开始注册前不管之前是否采集过手指，发送结束命令清空模块相关缓存。
    {
        return;
    }

    while(flag_register_success_cnt < REGCnt.toInt())
    {
        if(!FingerDetectStateChange(FigerisTakeOff))//检测到手指放上
        {
            return;//检测到手指未放上
        }

        //QThread::msleep(100);//发送注册命令前等待模块准备好

        switch(Registertemplate())
        {
        case ERR_SUCCESS:
            flag_register_success_cnt++;
            if(flag_register_success_cnt>=REGCnt.toInt())
            {
                textbuffer="采集"+REGCnt+"次手指完成！";
                ui->textEdit->setPlainText(textbuffer);
                ui->textEdit_debug->append(textbuffer);
                return;
            }
            textbuffer="采集第"+QString::number(flag_register_success_cnt,10)+"次手指成功，请移开重放手指！按“ESC”可结束本次注册。\n";
            break;
        case ERR_FALT:
            textbuffer="采集静脉特征失败,请重放手指！\n";
            break;
        case ERR_TEMPLATE_OCC:
            textbuffer="该手指已注册，请更换手指！\n";
            break;
        case ERR_REG_DIFF:
            textbuffer="与前面采集模板差异过大，请换手指或摆正姿势！\n";
            break;
        case ERR_REG_TIMEOUT:
            textbuffer="注册超时，请回到主界面重新注册！";
            ui->textEdit->setPlainText(textbuffer);
            ui->textEdit_debug->append(textbuffer);
            return;
            break;
        case ERR_REG_UNUSUAL:
            textbuffer="连续采集失败5次，请回到主界面重新注册！";
            ui->textEdit->setPlainText(textbuffer);
            ui->textEdit_debug->append(textbuffer);
            return;
            break;
        case ERR_REG_INFO:
            textbuffer="与前面采集手指下发信息不同，请回到主界面重新注册！";
            ui->textEdit->setPlainText(textbuffer);
            ui->textEdit_debug->append(textbuffer);
            return;
            break;
        case ERR_NO_FINGER:
            textbuffer="未检测到手指，请重放手指！\n";
            break;
        case ERR_REG_BUFFFULL:
            textbuffer="缓存区模板已达最大上限，请回到主界面重新注册！";
            ui->textEdit->setPlainText(textbuffer);
            ui->textEdit_debug->append(textbuffer);
            return;
            break;
        default:
            return;
            break;
        }
        ui->textEdit->setPlainText(textbuffer);
        //ui->textEdit_debug->append(textbuffer);

        //多次检测手指是否移开
        if(!FingerDetectStateChange(FigerisPutOn))//检测到手指移开
        {
            return;//检测到手指未移开
        }
    }
}

int MainWindow::Registertemplate()
{
    QByteArray TxData;
    //一个手指注册三个模板
    int FIDnum;
    int GIDnum;
    FIDnum = FID.toInt();
    GIDnum = GID.toInt();

    TxData[0] = ASCII_XON;
    TxData[1] = CMD_REGISTER;
    TxData[2] = ui->comboBox_Devid->currentText().toInt();
    TxData[3] = FIDnum%256;
    TxData[4] = FIDnum/256;
    TxData[5] = GIDnum%256;
    TxData[6] = Check_Xor((unsigned char *)(TxData.data()),6);
    TxData[7] = ASCII_XOFF;

    my_serialport->clear(QSerialPort::AllDirections);
    my_serialport->write(TxData);
    tempDataHex = MainWindow::ByteArrayToHexStr(TxData);//16进制转换成ASCII用于显示。

    if(ReadbuffDisplay(11000))//等待注册命令返回注册超时
    {
        return (unsigned char)requestData[5];
    }
    else
    {
        return -1;
    }
}

bool MainWindow::Registerbegin()
{
    //注册完成命令
    QByteArray TxData;

    TxData[0] = ASCII_XON;
    TxData[1] = CMD_REG_END;
    TxData[2] = ui->comboBox_Devid->currentText().toInt();
    TxData[3] = 0x00;
    TxData[4] = 0x00;
    TxData[5] = 0;
    TxData[6] = Check_Xor((unsigned char *)(TxData.data()),6);
    TxData[7] = ASCII_XOFF;

    my_serialport->clear(QSerialPort::AllDirections);
    my_serialport->write(TxData);
    tempDataHex = MainWindow::ByteArrayToHexStr(TxData);//16进制转换成ASCII用于显示。

    if(ReadbuffDisplay(2000))
    {
        switch((unsigned char)requestData[5])
        {
        case ERR_SUCCESS:
            return true;
            break;
        case ERR_FALT:
            textbuffer = "注册初始化失败";
            ui->textEdit->setPlainText(textbuffer);
            ui->textEdit_debug->append(textbuffer);
            break;
        default:
            break;
        }
    }
    return false;
}

void MainWindow::Registerend(char para)
{
    //注册完成命令
    QByteArray TxData;
    bool fileflag=false;
    QByteArray temp;

    TxData[0] = ASCII_XON;
    TxData[1] = CMD_REG_END;
    TxData[2] = ui->comboBox_Devid->currentText().toInt();
    TxData[3] = 0x00;
    TxData[4] = 0x00;
    TxData[5] = para-1;
    TxData[6] = Check_Xor((unsigned char *)(TxData.data()),6);
    TxData[7] = ASCII_XOFF;

    my_serialport->clear(QSerialPort::AllDirections);
    my_serialport->write(TxData);
    tempDataHex = MainWindow::ByteArrayToHexStr(TxData);//16进制转换成ASCII用于显示。

    if(ReadbuffDisplay(2000))
    {
        switch(para)
        {
        case 0x01:
            switch((unsigned char)requestData[5])
            {
            case ERR_SUCCESS:
                textbuffer=("取消注册成功");
                break;
            case ERR_FALT:
                textbuffer=("取消注册失败");
                break;
            }
            break;
        case 0x02:
            switch((unsigned char)requestData[5])
            {
            case ERR_SUCCESS:
                textbuffer="注册手指FID:"+FID+",GID:"+GID+"保存设备成功！";
                break;
            case ERR_FALT:
                textbuffer="注册到设备失败！";
                break;
            case ERR_INFOR_FULL:
                textbuffer="设备中的信息头空间已满！\n";
                break;
            case ERR_TEMPLATE_FULL:
                textbuffer="设备中的模板空间已满！\n";
                break;
            case ERR_FINGERID_OCC:
                textbuffer="FID已经存在！\n";
                break;
            case ERR_FALSH:
                textbuffer="flash操作失败,请重放手指！\n";
                break;
            }
            break;
        case 0x03:
            switch((unsigned char)requestData[5])
            {
            case ERR_SUCCESS:
                fileflag=true;
                textbuffer="注册手指FID:"+FID+",GID:"+GID+"模板数:"+REGCnt+"手指数据回传成功！";
                break;
            case ERR_FALT:
                textbuffer="手指数据回传失败！";
                break;
            }
            break;
        }
        ui->textEdit->setPlainText(textbuffer);
        ui->textEdit_debug->append(textbuffer);
    }

    if(fileflag)
    {
        temp = requestData.mid(11,512*(unsigned char)requestData[14]+18);
        QString filename;
        filename="./data/FID"+FID+".bin";
        QFile file(filename);
        if(file.open(QIODevice::WriteOnly))
        {
            QDataStream out(&file);
            out <<temp;
            file.close();
        }
        else
        {
            textbuffer="生成bin文件失败";
            ui->textEdit->setPlainText(textbuffer);
            ui->textEdit_debug->append(textbuffer);
            return;
        }
    }

}

void MainWindow::DeleteOnetemplate()
{
    QByteArray TxData;
    int FIDnum;
    FIDnum = FID.toInt();

    TxData[0] = ASCII_XON;
    TxData[1] = CMD_DELETE_ONE;
    TxData[2] = ui->comboBox_Devid->currentText().toInt();
    TxData[3] = FIDnum%256;
    TxData[4] = FIDnum/256;
    TxData[5] = 0x00;
    TxData[6] = Check_Xor((unsigned char *)(TxData.data()),6);
    TxData[7] = ASCII_XOFF;

    my_serialport->clear(QSerialPort::AllDirections);
    my_serialport->write(TxData);
    tempDataHex = MainWindow::ByteArrayToHexStr(TxData);//16进制转换成ASCII用于显示。

    if(ReadbuffDisplay(2000))
    {
        switch((unsigned char)requestData[5])
        {
        case ERR_SUCCESS:
            textbuffer="指定ID："+FID+"手指删除成功!";
            break;
        case ERR_FALT:
            textbuffer="删除操作失败";
            break;
        case ERR_FINGERID_NULL:
            textbuffer="无此手指FID，删除无效";
            break;
        case ERR_FALSH:
            textbuffer="flash操作失败";
            break;
        default:
            textbuffer="操作失败";
            break;
        }
        ui->textEdit->setPlainText(textbuffer);
        ui->textEdit_debug->append(textbuffer);
    }
}

void MainWindow::DeleteAlltemplate()
{
    QByteArray TxData;
    TxData[0] = ASCII_XON;
    TxData[1] = CMD_DELETE_ALL;
    TxData[2] = ui->comboBox_Devid->currentText().toInt();
    TxData[3] = 0x00;
    TxData[4] = 0x00;
    TxData[5] = 0x00;
    TxData[6] = Check_Xor((unsigned char *)(TxData.data()),6);
    TxData[7] = ASCII_XOFF;

    my_serialport->clear(QSerialPort::AllDirections);
    my_serialport->write(TxData);
    tempDataHex = MainWindow::ByteArrayToHexStr(TxData);//16进制转换成ASCII用于显示。
    if(ReadbuffDisplay(8000))//“删除所有手指”的回复数据需要6s，所以等待时间延长
    {
        switch((unsigned char)requestData[5])
        {
        case ERR_SUCCESS:
            textbuffer="删除所有手指成功!";
            break;
        case ERR_FALT:
            textbuffer="删除操作失败";
            break;
        case ERR_FALSH:
            textbuffer="flash操作失败";
            break;
        default:
            textbuffer="操作失败";
            break;
        }
        ui->textEdit->setPlainText(textbuffer);
        ui->textEdit_debug->append(textbuffer);
    }
}

void MainWindow::GetALLID()
{
    QString TemplateData;
    QByteArray TxData;
    TxData[0] = ASCII_XON;
    TxData[1] = CMD_UPLOAD_ALL_ID;
    TxData[2] = ui->comboBox_Devid->currentText().toInt();
    TxData[3] = 0x00;
    TxData[4] = 0x00;
    TxData[5] = 0x00;
    TxData[6] = Check_Xor((unsigned char *)(TxData.data()),6);
    TxData[7] = ASCII_XOFF;

    my_serialport->clear(QSerialPort::AllDirections);
    my_serialport->write(TxData);
    tempDataHex = MainWindow::ByteArrayToHexStr(TxData);//16进制转换成ASCII用于显示。

    if(ReadbuffDisplay(2000))
    {
        switch((unsigned char)requestData[5])
        {
        case ERR_SUCCESS:
            textbuffer="所有手指FID和GID获取成功!";
            TemplateData = tempDataHex.mid(33,((unsigned char)requestData[3]+(unsigned char)requestData[4]*256)*3);
            ui->textEdit_debug->append(TemplateData);
            break;
        case ERR_FINGERID_NULL:
            textbuffer="无注册手指";
            break;
        default:
            textbuffer="操作失败";
            break;
        }
        ui->textEdit->setPlainText(textbuffer);
        ui->textEdit_debug->append(textbuffer);
    }
}

void MainWindow::GetFIDInfo()
{
    QByteArray TxData;
    QString InforData;
    int FIDnum;
    FIDnum = FID.toInt();

    TxData[0] = ASCII_XON;
    TxData[1] = CMD_UPLOAD_INFOR;
    TxData[2] = ui->comboBox_Devid->currentText().toInt();
    TxData[3] = FIDnum%256;
    TxData[4] = FIDnum/256;
    TxData[5] = 0x00;
    TxData[6] = Check_Xor((unsigned char *)(TxData.data()),6);
    TxData[7] = ASCII_XOFF;

    my_serialport->clear(QSerialPort::AllDirections);
    my_serialport->write(TxData);
    tempDataHex = MainWindow::ByteArrayToHexStr(TxData);//16进制转换成ASCII用于显示。

    if(ReadbuffDisplay(2000))
    {
        switch((unsigned char)requestData[5])
        {
        case ERR_SUCCESS:
            textbuffer="指定ID："+FID+"手指信息头获取成功!";
            InforData = tempDataHex.mid(33,54);
            ui->textEdit_debug->append(InforData);
            break;
        case ERR_FINGERID_NULL:
            textbuffer="FID不存在";
            break;
        default:
            textbuffer="操作失败";
            break;
        }
        ui->textEdit->setPlainText(textbuffer);
        ui->textEdit_debug->append(textbuffer);
    }
}

void MainWindow::GetTemplate()
{
    QByteArray TxData;
    QString TemplateData;
    int FIDnum,fingernum;
    FIDnum = FID.toInt();
    fingernum = FinNo.toInt();

    TxData[0] = ASCII_XON;
    TxData[1] = CMD_UPLOAD_TEMPLATE;
    TxData[2] = ui->comboBox_Devid->currentText().toInt();
    TxData[3] = FIDnum%256;
    TxData[4] = FIDnum/256;
    TxData[5] = fingernum%256;
    TxData[6] = Check_Xor((unsigned char *)(TxData.data()),6);
    TxData[7] = ASCII_XOFF;

    my_serialport->clear(QSerialPort::AllDirections);
    my_serialport->write(TxData);
    tempDataHex = MainWindow::ByteArrayToHexStr(TxData);//16进制转换成ASCII用于显示。

    if(ReadbuffDisplay(2000))
    {
        switch((unsigned char)requestData[5])
        {
        case ERR_SUCCESS:
            textbuffer="指定FID："+FID+"的第"+FinNo+"个模板获取成功!";
            break;
        case ERR_FALT:
            textbuffer="无此模板，获取失败";
            break;
        case ERR_FINGERID_NULL:
            textbuffer="FID不存在";
            break;
        default:
            textbuffer="操作失败";
            break;
        }
        ui->textEdit->setPlainText(textbuffer);
        ui->textEdit_debug->append(textbuffer);
    }
}

void MainWindow::GetFIDAllData()
{
    QByteArray TxData;
    int FIDnum;
    bool fileflag=false;
    QByteArray temp;

    FIDnum = FID.toInt();
    TxData[0] = ASCII_XON;
    TxData[1] = CMD_UOLOAD_INFOR_TEMPLATES;
    TxData[2] = ui->comboBox_Devid->currentText().toInt();
    TxData[3] = FIDnum%256;
    TxData[4] = FIDnum/256;
    TxData[5] = 0x00;
    TxData[6] = Check_Xor((unsigned char *)(TxData.data()),6);
    TxData[7] = ASCII_XOFF;

    my_serialport->clear(QSerialPort::AllDirections);
    my_serialport->write(TxData);
    tempDataHex = MainWindow::ByteArrayToHexStr(TxData);//16进制转换成ASCII用于显示。

    if(ReadbuffDisplay(2000))
    {
        switch((unsigned char)requestData[5])
        {
        case ERR_SUCCESS:
            fileflag = true;

            textbuffer="指定ID："+FID+"手指和所有模板信息获取成功!";
            break;
        case ERR_FINGERID_NULL:
            textbuffer="FID不存在";
            break;
        default:
            textbuffer="操作失败";
            break;
        }
        ui->textEdit->setPlainText(textbuffer);
        ui->textEdit_debug->append(textbuffer);
    }

    if(fileflag)
    {
        temp = requestData.mid(11,512*(unsigned char)requestData[14]+18);
        QString filename;
        filename="./data/FID"+FID+".bin";
        QFile file(filename);
        if(file.open(QIODevice::WriteOnly))
        {
            QDataStream out(&file);
            out <<temp;
            file.close();
        }
        else
        {
            textbuffer="生成bin文件失败";
            ui->textEdit->setPlainText(textbuffer);
            ui->textEdit_debug->append(textbuffer);
            return;
        }
    }
}

void MainWindow::GetCurrentTmp()
{
    QString TemplateData;
    QByteArray TxData;
    TxData[0] = ASCII_XON;
    TxData[1] = CMD_UPLOAD_CURRENTTEMP;
    TxData[2] = ui->comboBox_Devid->currentText().toInt();
    TxData[3] = 0x00;
    TxData[4] = 0x00;
    TxData[6] = Check_Xor((unsigned char *)(TxData.data()),6);
    TxData[7] = ASCII_XOFF;

    my_serialport->clear(QSerialPort::AllDirections);
    my_serialport->write(TxData);
    tempDataHex = MainWindow::ByteArrayToHexStr(TxData);//16进制转换成ASCII用于显示。

    if(ReadbuffDisplay(2000))
    {
        switch((unsigned char)requestData[5])
        {
        case ERR_SUCCESS:
            textbuffer="当前模板信息获取成功!";
            break;
        case ERR_FALT:
            textbuffer="获取的当前模板信息不存在";
            break;
        default:
            textbuffer="操作失败";
            break;
        }
        ui->textEdit->setPlainText(textbuffer);
        ui->textEdit_debug->append(textbuffer);
    }
}

void MainWindow::DownloadFIDTmp()
{

    QByteArray arrhexs;

    QString filename;
    filename="./data/FID"+FID+".bin";
    QFile file(filename);
    if(file.open(QIODevice::ReadOnly))
    {
        QDataStream in(&file);
        in >>arrhexs;
        file.close();
    }
    else
    {
        textbuffer="打开bin文件失败";
        ui->textEdit->setPlainText(textbuffer);
        ui->textEdit_debug->append(textbuffer);
        return;
    }


    QByteArray TxData;
    TxData[0] = ASCII_XON;
    TxData[1] = CMD_DOWNLOAD_INFOR_TEMPLATES;
    TxData[2] = ui->comboBox_Devid->currentText().toInt();
    TxData[3] = arrhexs.length()%256;
    TxData[4] = arrhexs.length()/256;
    TxData[5] = 0x00;
    TxData[6] = Check_Xor((unsigned char *)(TxData.data()),6);
    TxData[7] = ASCII_XOFF;
    TxData[8] = ASCII_XON_DATA;
    TxData[9] = CMD_DOWNLOAD_INFOR_TEMPLATES;
    TxData[10] = ui->comboBox_Devid->currentText().toInt();

    TxData.replace(11,arrhexs.length(),arrhexs);
    TxData[11+arrhexs.length()] = Check_Xor((unsigned char *)(TxData.data()+8),arrhexs.length()+3);
    TxData[12+arrhexs.length()] = 0x0d;
    my_serialport->clear(QSerialPort::AllDirections);
    my_serialport->write(TxData);
    tempDataHex = MainWindow::ByteArrayToHexStr(TxData);//16进制转换成ASCII用于显示。

    if(ReadbuffDisplay(2000))
    {
        switch((unsigned char)requestData[5])
        {
        case ERR_SUCCESS:
            textbuffer="FID:"+FID+"手指信息下载成功!";
            break;
        case ERR_FALT:
            textbuffer="FID:"+FID+"手指信息下载失败!";
            break;
        case ERR_INFOR_FULL:
            textbuffer="设备中无空闲信息头空间";
            break;
        case ERR_TEMPLATE_FULL:
            textbuffer="设备中无空闲模板空间";
            break;
        case ERR_FINGERID_OCC:
            textbuffer="设备中已存在该手指";
            break;
        case ERR_FALSH:
            textbuffer="FLASH操作中失败";
            break;
        default:
            textbuffer="操作失败";
            break;
        }
        ui->textEdit->setPlainText(textbuffer);
        ui->textEdit_debug->append(textbuffer);
    }
}

void MainWindow::GetSoftwareVer()
{
    QByteArray TxData;
    TxData[0] = ASCII_XON;
    TxData[1] = CMD_UPLOAD_VERSION;
    TxData[2] = ui->comboBox_Devid->currentText().toInt();
    TxData[3] = 0x00;
    TxData[4] = 0x00;
    TxData[5] = 0x00;
    TxData[6] = Check_Xor((unsigned char *)(TxData.data()),6);
    TxData[7] = ASCII_XOFF;

    my_serialport->clear(QSerialPort::AllDirections);
    my_serialport->write(TxData);
    tempDataHex = MainWindow::ByteArrayToHexStr(TxData);//16进制转换成ASCII用于显示。

    if(ReadbuffDisplay(2000))
    {
        QString temp="";
        QString temp1="";
        switch((unsigned char)requestData[5])
        {
        case ERR_SUCCESS:
            for(int i=0;i<32;i++)
            {
                temp[i]=(unsigned char)requestData[i+11];
            }
            temp1=temp.mid(0,32);
            textbuffer=("软件版本号为："+temp1);
            break;
        case ERR_FALT:
            textbuffer="操作失败";
            break;
        default:
            textbuffer="操作失败";
            break;
        }
        ui->textEdit->setPlainText(textbuffer);
        ui->textEdit_debug->append(textbuffer);
    }
}

void MainWindow::GetRegisterFig()
{
    QByteArray TxData;
    TxData[0] = ASCII_XON;
    TxData[1] = CMD_UPLOAD_COUNT;
    TxData[2] = ui->comboBox_Devid->currentText().toInt();
    TxData[3] = 0x00;
    TxData[4] = 0x00;
    TxData[5] = 0x00;
    TxData[6] = Check_Xor((unsigned char *)(TxData.data()),6);
    TxData[7] = ASCII_XOFF;

    my_serialport->clear(QSerialPort::AllDirections);
    my_serialport->write(TxData);

    tempDataHex = MainWindow::ByteArrayToHexStr(TxData);//16进制转换成ASCII用于显示。

    if(ReadbuffDisplay(2000))
    {
        uint tempint;
        QString temp="";
        switch((unsigned char)requestData[5])
        {
        case ERR_SUCCESS:
            tempint = (unsigned char)requestData[3]+(unsigned char)requestData[4]*256;
            temp = QString::number(tempint,10);
            textbuffer=("获取成功，已注册手指数为"+temp);
            break;
        case ERR_FALT:
            textbuffer="操作失败";
            break;
        default:
            textbuffer="操作失败";
            break;
        }
        ui->textEdit->setPlainText(textbuffer);
        ui->textEdit_debug->append(textbuffer);
    }
}

void MainWindow::GetFingerstate()
{
    QByteArray TxData;
    TxData[0] = ASCII_XON;
    TxData[1] = CMD_CHK_FINGER;
    TxData[2] = ui->comboBox_Devid->currentText().toInt();
    TxData[3] = 0x00;
    TxData[4] = 0x00;
    TxData[5] = 0x00;
    TxData[6] = Check_Xor((unsigned char *)(TxData.data()),6);
    TxData[7] = ASCII_XOFF;

    my_serialport->clear(QSerialPort::AllDirections);
    my_serialport->write(TxData);
    tempDataHex = MainWindow::ByteArrayToHexStr(TxData);//16进制转换成ASCII用于显示。

    if(ReadbuffDisplay(2000))
    {
        switch((unsigned char)requestData[5])
        {
        case ERR_SUCCESS:
            textbuffer="传感器检测手指成功";
            break;
        case ERR_FALT:
            textbuffer="传感器检测手指失败";
            break;
        default:
            textbuffer="操作失败";
            break;
        }
        ui->textEdit->setPlainText(textbuffer);
        ui->textEdit_debug->append(textbuffer);
    }
}

void MainWindow::GetDeviceSer()
{
    QByteArray TxData;
    TxData[0] = ASCII_XON;
    TxData[1] = CMD_UPLOAD_SEQUENCE;
    TxData[2] = ui->comboBox_Devid->currentText().toInt();
    TxData[3] = 0x00;
    TxData[4] = 0x00;
    TxData[5] = 0x00;
    TxData[6] = Check_Xor((unsigned char *)(TxData.data()),6);
    TxData[7] = ASCII_XOFF;

    my_serialport->clear(QSerialPort::AllDirections);
    my_serialport->write(TxData);
    tempDataHex = MainWindow::ByteArrayToHexStr(TxData);//16进制转换成ASCII用于显示。

    if(ReadbuffDisplay(2000))
    {
        QString temp="";
        switch((unsigned char)requestData[5])
        {
        case ERR_SUCCESS:
            for(int i=0;i<32;i++)
            {
                temp[i]=(unsigned char)requestData[i+11];
            }
            textbuffer=("获取成功，设备序列号为："+temp);
            break;
        case ERR_FALT:
            textbuffer="获取设备序列号失败";
            break;
        default:
            textbuffer="操作失败";
            break;
        }
        ui->textEdit->setPlainText(textbuffer);
        ui->textEdit_debug->append(textbuffer);
    }
}

void MainWindow::SetBuadrate()
{
    if(CheckCOMisOpen()==false) return;

    QByteArray TxData;
    TxData[0] = ASCII_XON;
    TxData[1] = CMD_SET_BAUD;
    TxData[2] = ui->comboBox_Devid->currentText().toInt();

    switch(devBuad.toInt())
    {
    case 9600:
        TxData[3] = 0x01;
        break;
    case 19200:
        TxData[3] = 0x02;
        break;
    case 57600:
        TxData[3] = 0x06;
        break;
    case 115200:
        TxData[3] = 0x0C;
        break;
    default:
        TxData[3] = 0x55;
        break;
    }

    TxData[4] = 0x00;
    TxData[5] = 0x00;
    TxData[6] = Check_Xor((unsigned char *)(TxData.data()),6);
    TxData[7] = ASCII_XOFF;

    my_serialport->clear(QSerialPort::AllDirections);
    my_serialport->write(TxData);
    tempDataHex = MainWindow::ByteArrayToHexStr(TxData);//16进制转换成ASCII用于显示。

    if(ReadbuffDisplay(2000))
    {
        switch((unsigned char)requestData[5])
        {
        case ERR_SUCCESS:
            textbuffer=("设置波特率为"+devBuad+"成功");
            break;
        case ERR_FALT:
            textbuffer=("设置波特率参数错误");
            break;
        default:
            textbuffer=("操作失败");
            break;
        }
        ui->textEdit->setPlainText(textbuffer);
        ui->textEdit_debug->append(textbuffer);
    }
}

void MainWindow::SetDevid()
{
    if(CheckCOMisOpen()==false) return;

    QByteArray TxData;
    TxData[0] = ASCII_XON;
    TxData[1] = CMD_SET_DEVID;
    TxData[2] = ui->comboBox_Devid->currentText().toInt();
    TxData[3] = 0x00;
    TxData[4] = 0x00;
    TxData[5] = devid.toInt();
    TxData[6] = Check_Xor((unsigned char *)(TxData.data()),6);
    TxData[7] = ASCII_XOFF;

    my_serialport->clear(QSerialPort::AllDirections);
    my_serialport->write(TxData);
    tempDataHex = MainWindow::ByteArrayToHexStr(TxData);//16进制转换成ASCII用于显示。

    if(ReadbuffDisplay(2000))
    {
        switch((unsigned char)requestData[5])
        {
        case ERR_SUCCESS:
            textbuffer="设置设备号为"+devid+"成功";
            break;
        case ERR_FALT:
            textbuffer="设置DEVID错误";
            break;
        default:
            textbuffer="操作失败";
            break;
        }
        ui->textEdit->setPlainText(textbuffer);
        ui->textEdit_debug->append(textbuffer);
    }
}

