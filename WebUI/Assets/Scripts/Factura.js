const setDatos = () => {
    let url = new URL(window.location.href);

    let clave = url.searchParams.get("clave");
    let fecha = url.searchParams.get("fecha");
    let detalle = url.searchParams.get("detalle");
    let descuento = url.searchParams.get("descuento");
    let impuesto = url.searchParams.get("impuesto");
    let total = url.searchParams.get("total");

    $('#txt-clave').val(clave)
    $('#txt-fecha').val(fecha)
    $('#txt-detalle').val(detalle)
	$('#txt-descuento').val('$' + descuento)
    $('#txt-impuesto').val('$' + impuesto)
	$('#txt-total').val('$' + total)

	setTimeout(function () {
		printAsPDF(clave);
		printAsXML(clave, fecha, detalle, descuento, impuesto, total);
	}, 2000);

}


const printAsPDF = (clave) => {

	window.jsPDF = window.jspdf.jsPDF;

	var HTML_Width = $(".print-content").width();
	var HTML_Height = $(".print-content").height();
	var top_left_margin = 15;
	var PDF_Width = HTML_Width + (top_left_margin * 2);
	var PDF_Height = (PDF_Width * 1.5) + (top_left_margin * 2);
	var canvas_image_width = HTML_Width;
	var canvas_image_height = HTML_Height;

	var totalPDFPages = Math.ceil(HTML_Height / PDF_Height) - 1;

	html2canvas($(".print-content")[0]).then(function (canvas) {
		var imgData = canvas.toDataURL("image/jpeg", 1.0);
		var pdf = new jspdf.jsPDF('p', 'pt', [PDF_Width, PDF_Height]);
		pdf.addImage(imgData, 'JPG', top_left_margin, top_left_margin, canvas_image_width, canvas_image_height);
		for (var i = 1; i <= totalPDFPages; i++) {
			pdf.addPage(PDF_Width, PDF_Height);
			pdf.addImage(imgData, 'JPG', top_left_margin, -(PDF_Height * i) + (top_left_margin * 4), canvas_image_width, canvas_image_height);
		}
		pdf.save("factura-nolimits-"+clave+".pdf");
	});
}

const replaceSpaces = str => {
	str = str.toLowerCase().replaceAll(' ', '-');
	str = str.replaceAll(',', '-');
	return str.replaceAll(':', '-');
}
const replaceDate = data => {
	let str = data.replaceAll('/', '-');
	str = str.replaceAll(' ', '');
	str = str.replaceAll(',', '');
	return str.replaceAll(':', '-');
}


const printAsXML = (clave, fecha, detalle, descuento, impuesto, total) => {
	let fixDetalle = replaceSpaces(detalle);
	let fixFecha = replaceDate(fecha);

	let xmltext = "<root>"
				+ "<fecha><val-" + fixFecha + "></val-" + fixFecha + "></fecha>"
				+ "<clave-numerica><val-" + clave + "></val-" + clave + "></clave-numerica>"
				+ "<detalle><val-" + fixDetalle + "></val-" + fixDetalle + "></detalle>"
				+ "<descuento><val-" + descuento + "></val-" + descuento + "></descuento>"
				+ "<impuesto><val-" + impuesto + "></val-" + impuesto + "></impuesto>"
				+ "<total><val-" + total + "></val-" + total + "></total>"
				+ "</root>";

	var filename = "factura-nolimits-" + clave + ".xml";
	let pom = document.createElement('a');
	let bb = new Blob([xmltext], { type: 'text/plain' });

	pom.setAttribute('href', window.URL.createObjectURL(bb));
	pom.setAttribute('download', filename);

	pom.dataset.downloadurl = ['text/plain', pom.download, pom.href].join(':');
	pom.draggable = true;
	pom.classList.add('dragout');

	pom.click();
}

$(document).ready(function () {
	setDatos();
});