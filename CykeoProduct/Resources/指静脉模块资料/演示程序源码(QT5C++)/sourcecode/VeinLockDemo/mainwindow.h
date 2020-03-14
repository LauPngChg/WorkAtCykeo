#ifndef MAINWINDOW_H
#define MAINWINDOW_H

#include <QMainWindow>
#include <QtSerialPort/QSerialPort>
#include <QtSerialPort/QSerialPortInfo>
#include <QDebug>
#include <QString>
#include <QThread>
#include <QTime>
#include <QFile>
namespace Ui {
class MainWindow;
}

class MainWindow : public QMainWindow
{
    Q_OBJECT

public:
    explicit MainWindow(QWidget *parent = 0);
    ~MainWindow();

private slots:
    void DisplayPage(int PageID);

    void SP_refresh();

    unsigned char Check_Xor(unsigned char *data,unsigned int len);

    unsigned int GetRand(unsigned int MIN,unsigned int MAX);

    bool CheckCOMisOpen();

    void on_pBn_refresh_clicked();

    void on_pBn_comopen_clicked();

    void on_Btn_Digital_1_clicked();

    void on_Btn_Digital_2_clicked();

    void on_Btn_Digital_3_clicked();

    void on_Btn_Digital_4_clicked();

    void on_Btn_Digital_5_clicked();

    void on_Btn_Digital_6_clicked();

    void on_Btn_Digital_7_clicked();

    void on_Btn_Digital_8_clicked();

    void on_Btn_Digital_9_clicked();

    void on_Btn_Digital_0_clicked();

    void on_Btn_Esc_clicked();

    void on_Btn_Ent_clicked();

    void on_pB_cleartextdebug_clicked();

    void on_pB_cleartextRWdata_clicked();


    bool ReadbuffDisplay(uint waitms);

    void DigitalKeysOperation(int keysnum);

    int FingerDetect();

    bool FingerDetectStateChange(int state);

    void Verifytemplate(char cmd);

    void RegistAuto();

    int Registertemplate();

    void RegisterManyTimes();

    void Registerend(char para);

    bool Registerbegin();

    void DeleteOnetemplate();

    void DeleteAlltemplate();

    void GetALLID();

    void GetFIDInfo();

    void GetTemplate();

    void GetFIDAllData();

    void GetCurrentTmp();

    void DownloadFIDTmp();

    void GetSoftwareVer();

    void GetRegisterFig();

    void GetFingerstate();

    void GetDeviceSer();

    void SetBuadrate();

    void SetDevid();

private:
    Ui::MainWindow *ui;
    QSerialPort *my_serialport;
    QByteArray requestData;
    QString tempDataHex;
    QString textbuffer;
    QString devBuad;
    QString devid;
    QString secuLev;
    int CurrentPageID;//当前页面ID号
    QString FID,GID;
    QString FinNo;//
    QString REGCnt;//
    int flag_register_success_cnt;

public:
    //Byte序列转16进制字符串
    static QString ByteArrayToHexStr(QByteArray data)
    {
        QString temp="";
        QString hex=data.toHex();
        for (int i=0;i<hex.length();i=i+2)
        {
            temp+=hex.mid(i,2)+" ";
        }
        return temp.trimmed().toUpper();
    }
};

#define     NULLPage                    -1
#define     MainMenuPages               0

#define     VerifyPages                 1
#define     Verify_OneVsN_ExecuPage     11
#define     Verify_OneVsG_GetGIDPage    12
#define     Verify_OneVsG_ExecuPage     121
#define     Verify_OneVsOne_GetFIDPage  13
#define     Verify_OneVsOne_ExecuPage   131

#define     RegisterPages               2
#define     RegisterAutoPage_ExecuPage  21
#define     RegisterPage_GetREGCntPage  22
#define     RegisterPage_GetFIDPage     221
#define     RegisterPage_GetGIDPage     2211
#define     RegisterPage_ExecuPage      22111
#define     RegisterEndPage_GetChoPages 23
#define     RegisterEndPage_ExecuPage   231


#define     DeleteTmpPages              3
#define     DeleteOneTmp_GetFIDPage     31
#define     DeleteOneTmp_ExecuPage      311
#define     DeleteAllTmp_EnsurePage     32
#define     DeleteAllTmp_ExecuPage      322

#define     FIDDataPages                4
#define     GetALLID_ExecuPage          41
#define     GetFIDInfo_GetFIDPage       42
#define     GetFIDInfo_ExecuPage        421
#define     GetTemplate_GetFIDPage      43
#define     GetTemplate_GetFingnumPage  431
#define     GetTemplate_ExecuPage       4311
#define     GetFIDAllData_GetFIDPage    44
#define     GetFIDAllData_ExecuPage     441
#define     GetCurrentTmp_ExecuPage     45
#define     DownloadFIDTmp_GetFIDPage   46
#define     DownloadFIDTmp_ExecuPage    461

#define     SystemParaPages             5
#define     GetSoftwareVer_ExecuPage    51
#define     GetRegisterFig_ExecuPage    52
#define     GetFingerstate_ExecuPage    53
#define     GetDeviceSer_ExecuPage      54
#define     SetBaudrate_GetBaudpage     55
#define     SetBaudrate_ExecuPage       551
#define     SetDevid_GetDevid           56
#define     SetDevid_ExecuPage          661

//命令编码分配
#define CMD_ONE_VS_N                    (0x00)//采集特征并1：N比对
#define CMD_ONE_VS_G                    (0x01)//采集特征并1：G比对
#define CMD_ONE_VS_ONE                  (0x02)//采集特征并1：1比对

#define CMD_REGISTER                    (0x03)//注册手指静脉
#define CMD_REG_END                     (0x04)//结束注册

#define CMD_DELETE_ONE                  (0x05)//删除单个手指
#define CMD_DELETE_ALL                  (0x06)//删除所有信息

#define CMD_UPLOAD_ALL_ID               (0x07)//上传所有手指ID
#define CMD_UPLOAD_INFOR                (0x08)//上传指定手指信息
#define CMD_UPLOAD_TEMPLATE             (0x09)//上传指定手指模板
#define CMD_UOLOAD_INFOR_TEMPLATES      (0x0A)//上传指定手指以及对应模板
#define CMD_UPLOAD_CURRENTTEMP          (0x0B)//上传最近采集模板
#define CMD_DOWNLOAD_INFOR_TEMPLATES    (0x0C)//下载手指信息头和所有模板

#define CMD_UPLOAD_VERSION              (0x0D)//获取固件版本号
#define CMD_UPLOAD_COUNT                (0x0E)//获取手指注册数量
#define CMD_CHK_FINGER                  (0x0F)//检查手指状态
#define CMD_UPLOAD_SEQUENCE             (0x10)//获取序列号
#define CMD_SET_BAUD                    (0x11)//设置波特率
#define CMD_SET_DEVID                   (0x12)//设置设备编号

//错误编码
#define ERR_SUCCESS                     0x00    //操作成功
#define ERR_FALT                        0x01    //操作失败
#define ERR_TIMEOUT                     0x02    //操作超时
#define ERR_INFOR_FULL                  0x03    //信息头存储空间满
#define ERR_TEMPLATE_FULL               0x04    //模板存储空间满
#define ERR_TEMPLATE_OCC                0x05    //模板已存在
#define ERR_FINGERID_OCC                0x06    //FID已存在
#define ERR_FINGERID_NULL               0x07    //不存在该FID
#define ERR_GROUPID_NULL                0x08    //不存在该组号
#define ERR_FALSH                       0x09    //Flash操作失败
#define ERR_REG_DIFF                    0x0A    //采集生成特征与前一次差异过大
#define ERR_REG_TIMEOUT                 0x0B    //注册超时
#define ERR_REG_UNUSUAL                 0x0C    //连续注册失败次数过多
#define ERR_REG_INFO                    0x0D    //与前一次采集手指下发信息不同
#define ERR_NO_FINGER                   0x0E    //未检测到手指
#define ERR_REG_BUFFFULL                0x0F    //注册模板缓存区满

//部分命令发送数据包长度
#define VERSION_LEN      32       //固件版本号数据长度
#define SEQUENCE_LEN     32       //设备序列号数据长度

//通讯特殊字节
#define ASCII_XON           (0x40)
#define ASCII_XON_DATA      (0x3e)
#define ASCII_XOFF          (0x0D)
#define BROADCASTADDR       (0xff)

#define     FigerisTakeOff    1
#define     FigerisPutOn      0


#endif // MAINWINDOW_H
