<template>
    <div class="hello">
        <el-table :data="outdata" style="width: 100%">
            <el-table-column prop="ID" label="ID" width="180">
            </el-table-column>
            <el-table-column prop="Name" label="姓名" width="180">
            </el-table-column>
        </el-table>

        <button @click="export2Excel" type="button">导出</button>

        <a href="javascript:;" class="file">
            <input
                id="upload"
                type="file"
                @change="importfxx(this)"
                accept=".csv, application/vnd.openxmlformats-officedocument.spreadsheetml.sheet, application/vnd.ms-excel"
            />
        </a>
    </div>
</template>

<script>
export default {
    data() {
        return {
            outdata: [],
            tableData: [
                {
                    date: "2016-05-02",
                    name: "王小虎",
                    address: "上海市普陀区金沙江路 1518 弄",
                },
                {
                    date: "2016-05-04",
                    name: "王小虎",
                    address: "上海市普陀区金沙江路 1517 弄",
                },
                {
                    date: "2016-05-01",
                    name: "王小虎",
                    address: "上海市普陀区金沙江路 1519 弄",
                },
                {
                    date: "2016-05-03",
                    name: "王小虎",
                    address: "上海市普陀区金沙江路 1516 弄",
                },
            ],
        };
    },
    methods: {
        export2Excel() {
            require.ensure([], () => {
                const {
                    export_json_to_excel,
                } = require("../excel/Export2Excel"); // 这里 require 写你的Export2Excel.js的绝对地址
                const tHeader = ["日期", "名称", "地址"]; //对应表格输出的title
                const filterVal = ["date", "name", "address"]; // 对应表格输出的数据
                const list = this.tableData;
                const data = this.formatJson(filterVal, list);
                export_json_to_excel(tHeader, data, "列表excel"); //对应下载文件的名字
            });
        },
        formatJson(filterVal, jsonData) {
            return jsonData.map((v) => filterVal.map((j) => v[j]));
        },
        importfxx(obj) {
            let _this = this;
            // eslint-disable-next-line no-unused-vars
            let inputDOM = this.$refs.inputer;

            // 通过DOM取文件数据

            this.file = event.currentTarget.files[0];

            var rABS = false; // 是否将文件读取为二进制字符串

            var f = this.file;

            var reader = new FileReader();

            // if (!FileReader.prototype.readAsBinaryString) {

            FileReader.prototype.readAsBinaryString = function (f) {
                var binary = "";

                var rABS = false; // 是否将文件读取为二进制字符串

                // eslint-disable-next-line no-unused-vars
                var pt = this;

                var wb; // 读取完成的数据

                var reader = new FileReader();

                reader.onload = function (e) {
                    var bytes = new Uint8Array(reader.result);

                    var length = bytes.byteLength;

                    for (var i = 0; i < length; i++) {
                        binary += String.fromCharCode(bytes[i]);
                    }

                    var XLSX = require("xlsx");

                    if (rABS) {
                        // eslint-disable-next-line no-undef
                        wb = XLSX.read(btoa(fixdata(binary)), {
                            // 手动转化

                            type: "base64",
                        });
                    } else {
                        wb = XLSX.read(binary, {
                            type: "binary",
                        });
                    }

                    _this.outdata = XLSX.utils.sheet_to_json(
                        wb.Sheets[wb.SheetNames[0]]
                    ); // outdata 数组里面  这里面就是你想要的数据

                    console.log(_this.outdata);

                    _this.$message({
                        message: "请耐心等待导入成功",

                        type: "success",
                    });
                };

                reader.readAsArrayBuffer(f);
            };

            if (rABS) {
                reader.readAsArrayBuffer(f);
            } else {
                reader.readAsBinaryString(f);
            }
        },
    },
};
</script>