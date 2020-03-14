/********************************************************************************
** Form generated from reading UI file 'mainwindow.ui'
**
** Created by: Qt User Interface Compiler version 5.5.1
**
** WARNING! All changes made in this file will be lost when recompiling UI file!
********************************************************************************/

#ifndef UI_MAINWINDOW_H
#define UI_MAINWINDOW_H

#include <QtCore/QVariant>
#include <QtWidgets/QAction>
#include <QtWidgets/QApplication>
#include <QtWidgets/QButtonGroup>
#include <QtWidgets/QComboBox>
#include <QtWidgets/QGroupBox>
#include <QtWidgets/QHeaderView>
#include <QtWidgets/QLabel>
#include <QtWidgets/QMainWindow>
#include <QtWidgets/QMenuBar>
#include <QtWidgets/QPushButton>
#include <QtWidgets/QStatusBar>
#include <QtWidgets/QTextEdit>
#include <QtWidgets/QToolBar>
#include <QtWidgets/QWidget>

QT_BEGIN_NAMESPACE

class Ui_MainWindow
{
public:
    QWidget *centralWidget;
    QGroupBox *groupBox;
    QPushButton *Btn_Digital_1;
    QPushButton *Btn_Digital_2;
    QPushButton *Btn_Digital_3;
    QPushButton *Btn_Digital_4;
    QPushButton *Btn_Digital_5;
    QPushButton *Btn_Digital_6;
    QPushButton *Btn_Digital_7;
    QPushButton *Btn_Digital_8;
    QPushButton *Btn_Digital_9;
    QPushButton *Btn_Esc;
    QPushButton *Btn_Digital_0;
    QPushButton *Btn_Ent;
    QTextEdit *textEdit;
    QGroupBox *groupBox_2;
    QGroupBox *groupBox_5;
    QTextEdit *textEdit_RWdata;
    QPushButton *pB_cleartextRWdata;
    QGroupBox *groupBox_6;
    QPushButton *pBn_comopen;
    QPushButton *pBn_refresh;
    QComboBox *comboBox;
    QLabel *label;
    QComboBox *comboBox_combps;
    QLabel *label_2;
    QLabel *label_3;
    QComboBox *comboBox_Devid;
    QGroupBox *groupBox_4;
    QTextEdit *textEdit_debug;
    QPushButton *pB_cleartextdebug;
    QMenuBar *menuBar;
    QToolBar *mainToolBar;
    QStatusBar *statusBar;

    void setupUi(QMainWindow *MainWindow)
    {
        if (MainWindow->objectName().isEmpty())
            MainWindow->setObjectName(QStringLiteral("MainWindow"));
        MainWindow->setEnabled(true);
        MainWindow->resize(750, 500);
        MainWindow->setMinimumSize(QSize(750, 500));
        MainWindow->setMaximumSize(QSize(1200, 500));
        MainWindow->setContextMenuPolicy(Qt::DefaultContextMenu);
        MainWindow->setAnimated(true);
        centralWidget = new QWidget(MainWindow);
        centralWidget->setObjectName(QStringLiteral("centralWidget"));
        groupBox = new QGroupBox(centralWidget);
        groupBox->setObjectName(QStringLiteral("groupBox"));
        groupBox->setGeometry(QRect(10, 10, 341, 431));
        Btn_Digital_1 = new QPushButton(groupBox);
        Btn_Digital_1->setObjectName(QStringLiteral("Btn_Digital_1"));
        Btn_Digital_1->setGeometry(QRect(10, 230, 91, 40));
        QFont font;
        font.setFamily(QStringLiteral("Arial"));
        font.setPointSize(16);
        font.setBold(true);
        font.setWeight(75);
        Btn_Digital_1->setFont(font);
        Btn_Digital_2 = new QPushButton(groupBox);
        Btn_Digital_2->setObjectName(QStringLiteral("Btn_Digital_2"));
        Btn_Digital_2->setGeometry(QRect(120, 230, 91, 40));
        Btn_Digital_2->setFont(font);
        Btn_Digital_3 = new QPushButton(groupBox);
        Btn_Digital_3->setObjectName(QStringLiteral("Btn_Digital_3"));
        Btn_Digital_3->setGeometry(QRect(230, 230, 91, 40));
        Btn_Digital_3->setFont(font);
        Btn_Digital_4 = new QPushButton(groupBox);
        Btn_Digital_4->setObjectName(QStringLiteral("Btn_Digital_4"));
        Btn_Digital_4->setGeometry(QRect(10, 280, 91, 40));
        Btn_Digital_4->setFont(font);
        Btn_Digital_5 = new QPushButton(groupBox);
        Btn_Digital_5->setObjectName(QStringLiteral("Btn_Digital_5"));
        Btn_Digital_5->setGeometry(QRect(120, 280, 91, 40));
        Btn_Digital_5->setFont(font);
        Btn_Digital_6 = new QPushButton(groupBox);
        Btn_Digital_6->setObjectName(QStringLiteral("Btn_Digital_6"));
        Btn_Digital_6->setGeometry(QRect(230, 280, 91, 40));
        Btn_Digital_6->setFont(font);
        Btn_Digital_7 = new QPushButton(groupBox);
        Btn_Digital_7->setObjectName(QStringLiteral("Btn_Digital_7"));
        Btn_Digital_7->setGeometry(QRect(10, 330, 91, 40));
        Btn_Digital_7->setFont(font);
        Btn_Digital_8 = new QPushButton(groupBox);
        Btn_Digital_8->setObjectName(QStringLiteral("Btn_Digital_8"));
        Btn_Digital_8->setGeometry(QRect(120, 330, 91, 40));
        Btn_Digital_8->setFont(font);
        Btn_Digital_9 = new QPushButton(groupBox);
        Btn_Digital_9->setObjectName(QStringLiteral("Btn_Digital_9"));
        Btn_Digital_9->setGeometry(QRect(230, 330, 91, 40));
        Btn_Digital_9->setFont(font);
        Btn_Esc = new QPushButton(groupBox);
        Btn_Esc->setObjectName(QStringLiteral("Btn_Esc"));
        Btn_Esc->setGeometry(QRect(10, 380, 91, 40));
        Btn_Esc->setFont(font);
        Btn_Digital_0 = new QPushButton(groupBox);
        Btn_Digital_0->setObjectName(QStringLiteral("Btn_Digital_0"));
        Btn_Digital_0->setGeometry(QRect(120, 380, 91, 40));
        Btn_Digital_0->setFont(font);
        Btn_Ent = new QPushButton(groupBox);
        Btn_Ent->setObjectName(QStringLiteral("Btn_Ent"));
        Btn_Ent->setGeometry(QRect(230, 380, 91, 40));
        Btn_Ent->setFont(font);
        textEdit = new QTextEdit(groupBox);
        textEdit->setObjectName(QStringLiteral("textEdit"));
        textEdit->setGeometry(QRect(10, 30, 321, 191));
        QFont font1;
        font1.setFamily(QStringLiteral("Arial"));
        font1.setPointSize(12);
        font1.setBold(false);
        font1.setItalic(false);
        font1.setWeight(50);
        textEdit->setFont(font1);
        textEdit->setStyleSheet(QStringLiteral(""));
        textEdit->setReadOnly(true);
        groupBox_2 = new QGroupBox(centralWidget);
        groupBox_2->setObjectName(QStringLiteral("groupBox_2"));
        groupBox_2->setGeometry(QRect(350, 10, 391, 431));
        groupBox_5 = new QGroupBox(groupBox_2);
        groupBox_5->setObjectName(QStringLiteral("groupBox_5"));
        groupBox_5->setGeometry(QRect(10, 280, 371, 141));
        textEdit_RWdata = new QTextEdit(groupBox_5);
        textEdit_RWdata->setObjectName(QStringLiteral("textEdit_RWdata"));
        textEdit_RWdata->setGeometry(QRect(20, 20, 331, 101));
        textEdit_RWdata->setReadOnly(true);
        pB_cleartextRWdata = new QPushButton(groupBox_5);
        pB_cleartextRWdata->setObjectName(QStringLiteral("pB_cleartextRWdata"));
        pB_cleartextRWdata->setGeometry(QRect(270, 0, 81, 23));
        groupBox_6 = new QGroupBox(groupBox_2);
        groupBox_6->setObjectName(QStringLiteral("groupBox_6"));
        groupBox_6->setGeometry(QRect(10, 20, 371, 91));
        pBn_comopen = new QPushButton(groupBox_6);
        pBn_comopen->setObjectName(QStringLiteral("pBn_comopen"));
        pBn_comopen->setGeometry(QRect(20, 20, 101, 23));
        pBn_refresh = new QPushButton(groupBox_6);
        pBn_refresh->setObjectName(QStringLiteral("pBn_refresh"));
        pBn_refresh->setGeometry(QRect(20, 40, 101, 21));
        comboBox = new QComboBox(groupBox_6);
        comboBox->setObjectName(QStringLiteral("comboBox"));
        comboBox->setGeometry(QRect(270, 20, 81, 22));
        label = new QLabel(groupBox_6);
        label->setObjectName(QStringLiteral("label"));
        label->setGeometry(QRect(190, 20, 51, 21));
        comboBox_combps = new QComboBox(groupBox_6);
        comboBox_combps->setObjectName(QStringLiteral("comboBox_combps"));
        comboBox_combps->setGeometry(QRect(270, 40, 81, 22));
        label_2 = new QLabel(groupBox_6);
        label_2->setObjectName(QStringLiteral("label_2"));
        label_2->setGeometry(QRect(190, 40, 71, 16));
        label_3 = new QLabel(groupBox_6);
        label_3->setObjectName(QStringLiteral("label_3"));
        label_3->setGeometry(QRect(190, 60, 54, 12));
        comboBox_Devid = new QComboBox(groupBox_6);
        comboBox_Devid->setObjectName(QStringLiteral("comboBox_Devid"));
        comboBox_Devid->setGeometry(QRect(270, 60, 81, 22));
        groupBox_4 = new QGroupBox(groupBox_2);
        groupBox_4->setObjectName(QStringLiteral("groupBox_4"));
        groupBox_4->setGeometry(QRect(10, 120, 371, 141));
        textEdit_debug = new QTextEdit(groupBox_4);
        textEdit_debug->setObjectName(QStringLiteral("textEdit_debug"));
        textEdit_debug->setGeometry(QRect(20, 20, 331, 101));
        textEdit_debug->setReadOnly(true);
        pB_cleartextdebug = new QPushButton(groupBox_4);
        pB_cleartextdebug->setObjectName(QStringLiteral("pB_cleartextdebug"));
        pB_cleartextdebug->setGeometry(QRect(270, 0, 81, 23));
        MainWindow->setCentralWidget(centralWidget);
        menuBar = new QMenuBar(MainWindow);
        menuBar->setObjectName(QStringLiteral("menuBar"));
        menuBar->setGeometry(QRect(0, 0, 750, 23));
        MainWindow->setMenuBar(menuBar);
        mainToolBar = new QToolBar(MainWindow);
        mainToolBar->setObjectName(QStringLiteral("mainToolBar"));
        MainWindow->addToolBar(Qt::TopToolBarArea, mainToolBar);
        statusBar = new QStatusBar(MainWindow);
        statusBar->setObjectName(QStringLiteral("statusBar"));
        MainWindow->setStatusBar(statusBar);

        retranslateUi(MainWindow);

        QMetaObject::connectSlotsByName(MainWindow);
    } // setupUi

    void retranslateUi(QMainWindow *MainWindow)
    {
        MainWindow->setWindowTitle(QApplication::translate("MainWindow", "\351\227\250\351\224\201\346\274\224\347\244\272\347\250\213\345\272\217", 0));
        groupBox->setTitle(QApplication::translate("MainWindow", "\345\244\226\351\203\250\347\225\214\351\235\242", 0));
        Btn_Digital_1->setText(QApplication::translate("MainWindow", "1", 0));
        Btn_Digital_2->setText(QApplication::translate("MainWindow", "2", 0));
        Btn_Digital_3->setText(QApplication::translate("MainWindow", "3", 0));
        Btn_Digital_4->setText(QApplication::translate("MainWindow", "4", 0));
        Btn_Digital_5->setText(QApplication::translate("MainWindow", "5", 0));
        Btn_Digital_6->setText(QApplication::translate("MainWindow", "6", 0));
        Btn_Digital_7->setText(QApplication::translate("MainWindow", "7", 0));
        Btn_Digital_8->setText(QApplication::translate("MainWindow", "8", 0));
        Btn_Digital_9->setText(QApplication::translate("MainWindow", "9", 0));
        Btn_Esc->setText(QApplication::translate("MainWindow", "ESC", 0));
        Btn_Digital_0->setText(QApplication::translate("MainWindow", "0", 0));
        Btn_Ent->setText(QApplication::translate("MainWindow", "ENT", 0));
        groupBox_2->setTitle(QApplication::translate("MainWindow", "\345\206\205\351\203\250\344\277\241\346\201\257", 0));
        groupBox_5->setTitle(QApplication::translate("MainWindow", "\351\200\232\350\256\257\347\233\221\346\216\247", 0));
        pB_cleartextRWdata->setText(QApplication::translate("MainWindow", "\346\270\205\347\251\272\346\230\276\347\244\272", 0));
        groupBox_6->setTitle(QApplication::translate("MainWindow", "\344\270\262\345\217\243\351\205\215\347\275\256", 0));
        pBn_comopen->setText(QApplication::translate("MainWindow", "\346\211\223\345\274\200\344\270\262\345\217\243", 0));
        pBn_refresh->setText(QApplication::translate("MainWindow", "\345\210\267\346\226\260\344\270\262\345\217\243", 0));
        label->setText(QApplication::translate("MainWindow", "\344\270\262\345\217\243\345\217\267\357\274\232", 0));
        comboBox_combps->clear();
        comboBox_combps->insertItems(0, QStringList()
         << QApplication::translate("MainWindow", "9600", 0)
         << QApplication::translate("MainWindow", "19200", 0)
         << QApplication::translate("MainWindow", "57600", 0)
         << QApplication::translate("MainWindow", "115200", 0)
        );
        label_2->setText(QApplication::translate("MainWindow", "\344\270\262\345\217\243\346\263\242\347\211\271\347\216\207\357\274\232", 0));
        label_3->setText(QApplication::translate("MainWindow", "\350\256\276\345\244\207\347\274\226\345\217\267\357\274\232", 0));
        groupBox_4->setTitle(QApplication::translate("MainWindow", "\344\277\241\346\201\257\346\217\220\347\244\272", 0));
        pB_cleartextdebug->setText(QApplication::translate("MainWindow", "\346\270\205\347\251\272\346\230\276\347\244\272", 0));
    } // retranslateUi

};

namespace Ui {
    class MainWindow: public Ui_MainWindow {};
} // namespace Ui

QT_END_NAMESPACE

#endif // UI_MAINWINDOW_H
