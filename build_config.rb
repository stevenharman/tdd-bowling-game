@build = {
	:solution => File.join(File.dirname(__FILE__), 'Source', "Bowling.sln"),
	:config => :Debug,
	:gallio => File.join(File.dirname(__FILE__), %w[Libraries Gallio Gallio.Echo.exe]),
	:version => '0.0.1'
}