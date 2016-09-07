<%@ Page Language="C#" AutoEventWireup="true" CodeFile="slideTest.aspx.cs" Inherits="slideTest" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
<!--flickerplate所需的包-->
<script src="js/min/jquery-v1.10.2.min.js" type="text/javascript"></script>
<script src="js/min/modernizr-custom-v2.7.1.min.js" type="text/javascript"></script>
<script src="js/min/jquery-finger-v0.1.0.min.js" type="text/javascript"></script>
<link href="css/flickerplate.css"  type="text/css" rel="stylesheet"/>
<script src="js/min/flickerplate.min.js" type="text/javascript"></script>

<script type="text/javascript">
    $(document).ready(function () {
        $('.a').flicker();
    });
</script>

</head>
<body >
    <form id="form1" runat="server">
    <div style="width:1280px;">
        <div class="a">
          <ul>
             <li style="background-image: url('.../')">
                <div class="flick-title">《返老还童》</div>
                <div class="flick-sub-text">人都是孤独的。但可怕的不是孤独，而是惧怕孤独。</div>
              </li>
              <li style="background-image:url('http://localhost:47023/yulu/slide/img/field.jpg')">
                <div class="flick-title">《返老还童》2</div>
                <div class="flick-sub-text">人都是孤独的。但可怕的不是孤独，而是惧怕孤独。2</div>
              </li>
              <li style="background-image: url('http://localhost:47023/yulu/slide/img/frozen-water.jpg')">
                <div class="flick-title">Flickerplate Is Working</div>
                <div class="flick-sub-text">Heaven forbid this package you downloaded is broken. That wouldn't be embarrassing at all.</div>
              </li>
            </ul>
        </div>
    </div>
    </form>
</body>
</html>
