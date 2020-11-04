@ECHO OFF
for %%b in ("DashBoardComplianceTest.bat" "DesinAndMiscTest.bat" "MachineLearningAndRecommendation.bat" "P1RecommendationAndContentTagTest.bat" "P1RegressionSectionManagementTest.bat" "P1RegressionTest2.bat" "P1RegressionTest8.bat" "PlaylistTest.bat" "RequiredTrainingTest.bat" "SectionManagementTest_NF.bat")
do call %%b|| exit /b 1
REM call TestBatchFiles/DashBoardComplianceTest.bat
rem call TestBatchFiles/DesinAndMiscTest.bat
rem call TestBatchFiles/MachineLearningAndRecommendation.bat
REM call TestBatchFiles/P1RecommendationAndContentTagTest.bat
REM call TestBatchFiles/P1RegressionSectionManagementTest.bat
REM call TestBatchFiles/P1RegressionTest2.bat
REM call TestBatchFiles/P1RegressionTest8.bat
REM call TestBatchFiles/PlaylistTest.bat
REM call TestBatchFiles/RequiredTrainingTest.bat
REM call TestBatchFiles/SectionManagementTest_NF.bat
